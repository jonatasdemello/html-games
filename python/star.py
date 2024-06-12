from graphics import *
import math

def main():
	win = GraphWin("Star", 400, 400)

	# for (let t=0; t<12.56; t+=.05)
	# 12.56 / 0.05 = 251.2
	for t in range(251):
		t_val = t * 0.05
		x = 30 * math.cos(t_val) + 20 * math.cos(1.5 * t_val)
		y = 30 * math.sin(t_val) - 20 * math.sin(1.5 * t_val)
		v = 100 - y
		h = 128 + x
		win.plot(h*2, v*2)

	win.getMouse() # pause for click in window
	win.close()

main()
