var utils = {};

function drawAxes(canvas, ctx)
{
	//var canvas = document.getElementById("drawingCanvas");
	//var context = canvas.getContext("2d");

    ctx.font = "10px Arial";
    ctx.fillStyle = "rgb(0,0,0)";
    // X-axis
    for (var i=0; i<canvas.width; i+=50)
    {
        ctx.fillText(i,i,10);
    }
    // Y-axis
    for (var i=0; i<canvas.height; i+=50)
    {
        ctx.fillText(i,0,i);
    }
}

function drawAxes1(canvas, ctx)
{
	for (var x = 0; x < canvas.width; x += 50)
	{
		ctx.fillText(x, x, 10);
	}

	for (var y = 0; y < canvas.height; y += 50)
	{
		ctx.fillText(y, 0, y);
	}
}

function plot(x, y, ctx)
{
	ctx.fillStyle = "rgb(" + x + "," + y + ",40)";
	ctx.fillRect(x * 2, (200-y) * 2, 1, 1);
}

