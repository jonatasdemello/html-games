﻿using System.Collections;

namespace Wumpus
{
    internal class Program
    {
        public static int Main(string[] args)
        {
            string input;
            bool playAgain;
            int result;
            string setupFileName;
            StreamReader streamReader;
            WumpusLogic wumpusLogic;

            result = 0;

            Console.Write(
                "*** Wumpus .NET ***\n\nBased on:\n\n\n{0}\n{1}\n{2}\n\n\n\n",
                "WUMPUS 2".PadLeft(33), "CREATIVE COMPUTING".PadLeft(38),
                "MORRISTOWN  NEW JERSEY".PadLeft(40));

            Console.Write("INSTRUCTIONS? (Y/N)");
            input = Console.ReadLine().ToUpper();
            if (input.StartsWith("Y"))
            {
                Console.Write(TextPresentation.INSTRUCTIONS);
            }

            playAgain = false;
            wumpusLogic = null;
            do
            {
                if (wumpusLogic == null)
                {
                    setupFileName = string.Empty;
                    do
                    {
                        Console.Write("CAVE #(0-6) ");
                        input = Console.ReadLine();
                        Console.Write("\n");
                        input = input.Trim();
                        if (input?.Length == 0)
                        {
                            input = "X";
                        }
                        switch (input[0])
                        {
                            case '0':
                                setupFileName = TextPresentation.DODECAHEDRON_FILENAME;
                                break;

                            case '1':
                                setupFileName = TextPresentation.MOBIUS_FILENAME;
                                break;

                            case '2':
                                setupFileName = TextPresentation.BEADS_FILENAME;
                                break;

                            case '3':
                                setupFileName = TextPresentation.TORUS_FILENAME;
                                break;

                            case '4':
                                setupFileName = TextPresentation.DENDRITE_FILENAME;
                                break;

                            case '5':
                                setupFileName = TextPresentation.LATTICE_FILENAME;
                                break;

                            case '6':
                                Console.Write("Wumpus XML Filename: ");
                                setupFileName = Console.ReadLine().Trim();
                                break;

                            default:
                                Console.Write("ERROR  \n");
                                Console.ReadLine();
                                Console.Write("\n");
                                break;
                        }
                    } while (setupFileName == string.Empty);

                    if (!File.Exists(setupFileName))
                    {
                        setupFileName = Path.Combine(Environment.CurrentDirectory, "..\\..\\" + setupFileName);
                    }

                    streamReader = null;
                    try
                    {
                        streamReader = File.OpenText(setupFileName);
                        wumpusLogic = new WumpusLogic(streamReader);
                    }
                    catch
                    {
                        Console.Write(
                            "{0}:\nError: Unable to read Wumpus XML file, {1}.\n",
                            TextPresentation.APP_NAME, setupFileName);
                        result = TextPresentation.INPUT_FILE_ERROR;
                    }
                    finally
                    {
                        if (streamReader != null)
                        {
                            streamReader.Close();
                        }
                    }
                }

                if ((result == 0) && (wumpusLogic != null))
                {
                    Console.Write("HUNT THE WUMPUS\n");
                    try
                    {
                        while (wumpusLogic.Status ==
                            GameStatus.InPlay)
                        {
                            PrintHazardWarningsAndLocation(wumpusLogic);
                            Console.Write("SHOOT OR MOVE ");
                            input = Console.ReadLine().TrimStart().ToUpper();
                            if (input.StartsWith("M"))
                            {
                                HandleMove(wumpusLogic);
                            }
                            else if (input.StartsWith("S"))
                            {
                                HandleShoot(wumpusLogic);
                            }
                            else
                            {
                                Console.Write("ERROR   ");
                                Console.ReadLine();
                            }
                        }
                        if (wumpusLogic.Status == GameStatus.Lost)
                        {
                            Console.Write(
                                "HA HA HA - YOU LOOSE!\n");
                        }
                        else
                        {
                            Console.Write(
                                "HEE HEE HEE - THE WUMPUS'LL GET YOU NEXT TIME!!\n");
                        }
                        Console.Write("PLAY AGAIN");
                        input = Console.ReadLine().TrimStart().ToUpper();
                        playAgain = input.StartsWith("Y");
                        Console.Write("\n\n");
                        if (playAgain)
                        {
                            Console.Write("SAME SET-UP ");
                            input = Console.ReadLine().TrimStart().ToUpper();
                            if (input.StartsWith("Y"))
                            {
                                wumpusLogic.RestartGame();
                            }
                            else
                            {
                                wumpusLogic = null;
                            }
                        }
                    }
                    catch
                    {
                        Console.Write(
                            "{0}:\nError: Game error.\n");
                        result = TextPresentation.GAME_ERROR;
                    }
                }
            } while (playAgain && (result == 0));

            return result;
        }

        private static void HandleMove(WumpusLogic wumpusLogic)
        {
            IEnumerator enumerator;
            string input;
            ICollection movementResults;

            input = string.Empty;
            do
            {
                Console.Write("WHERE TO ");
                input = Console.ReadLine().Trim();
                Console.Write("\n");
                if (!wumpusLogic.PlayerNode.IsAdjacentNode(input))
                {
                    Console.Write("NOT POSSIBLE - {0}\n", input);
                    Console.ReadLine();
                    input = string.Empty;
                }
            } while (input == string.Empty);

            movementResults = wumpusLogic.Move(input);
            enumerator = movementResults.GetEnumerator();

            while (enumerator.MoveNext())
            {
                switch ((MovementResult)enumerator.Current)
                {
                    case MovementResult.BumpedAWumpus:
                        Console.Write("... OOPS! BUMPED A WUMPUS!\n");
                        break;

                    case MovementResult.FellInAPit:
                        Console.Write("YYYIIIEEEE . . . FELL IN A PIT\n");
                        break;

                    case MovementResult.GotByWumpus:
                        Console.Write(TextPresentation.GOT_BY_WUMPUS_STRING);
                        break;

                    case MovementResult.SuperBatSnatch:
                        Console.Write(
                            "ZAP--SUPER BAT SNATCH! ELSEWHERESVILLE FOR YOU!\n");
                        break;
                }
            }
        }

        public static void HandleShoot(WumpusLogic wumpusLogic)
        {
            string input;
            WumpusLogic.Node node;
            int numShots;
            Queue shots;

            numShots = -1;
            do
            {
                Console.Write("NO. OF ROOMS ");
                input = Console.ReadLine().Trim();
                try
                {
                    numShots = Convert.ToInt32(input);
                }
                catch
                {
                    numShots = -1;
                }

                if ((numShots < 1) ||
                    (numShots > WumpusLogic.MaxShots))
                {
                    numShots = -1;
                    Console.Write("ERROR   ");
                    Console.ReadLine();
                }
            } while (numShots < 1);

            shots = new Queue();
            while (numShots > 0)
            {
                Console.Write("ROOM #");
                input = Console.ReadLine().Trim();
                Console.Write("\n");
                node = wumpusLogic.GetNodeByName(input);

                if (node == null)
                {
                    Console.Write("ERROR   ");
                    Console.ReadLine();
                }
                else
                {
                    shots.Enqueue(node);
                    numShots--;
                }
            }

            switch (wumpusLogic.Shoot(shots))
            {
                case ShotResult.GotByWumpus:
                    Console.Write(TextPresentation.GOT_BY_WUMPUS_STRING);
                    break;

                case ShotResult.Missed:
                    Console.Write("MISSED\n");
                    break;

                case ShotResult.NoMoreArrows:
                    Console.Write("YOU HAVE USED ALL YOUR ARROWS.\n");
                    break;

                case ShotResult.ShotSelf:
                    Console.Write("OUCH! ARROW GOT YOU!\n");
                    break;

                case ShotResult.ShotWumpus:
                    Console.Write(
                        "AHA! YOU GOT THE WUMPUS! HE WAS IN ROOM {0}\n",
                        wumpusLogic.WumpusNode.Name);
                    break;
            }
        }

        private static void PrintHazardWarningsAndLocation(WumpusLogic wumpusLogic)
        {
            IEnumerator enumerator;
            SurroundingHazards hazards;
            WumpusLogic.Node node;

            Console.Write("\n");

            hazards = wumpusLogic.GetSurroundingHazards();
            if ((hazards & SurroundingHazards.WumpusNearby) != 0)
            {
                Console.Write("I SMELL A WUMPUS!\n");
            }
            if ((hazards & SurroundingHazards.PitNearby) != 0)
            {
                Console.Write("I FEEL A DRAFT!\n");
            }
            if ((hazards & SurroundingHazards.BatNearby) != 0)
            {
                Console.Write("BATS NEARBY!\n");
            }

            Console.Write("YOU ARE IN ROOM {0}\n", wumpusLogic.PlayerNode.Name);

            Console.Write("TUNNELS LEAD TO");
            enumerator = wumpusLogic.PlayerNode.LinkedNodes.GetEnumerator();
            while (enumerator.MoveNext())
            {
                node = enumerator.Current as WumpusLogic.Node;
                if (node != null)
                {
                    Console.Write(" {0}", node.Name);
                }
            }
            Console.Write("\n\n");
        }
    }
}