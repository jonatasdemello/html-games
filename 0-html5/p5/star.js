function setup() {
  createCanvas(500, 400);
}

function draw() {
  background(50);
  
  stroke(255, 165, 0);
  strokeWeight(2);
  
  var x=0, y=0, v=0, h=0;
  
  for (var t=0; t<12.56; t+=.05) {
    x = 30 * cos(t) + 20 * cos(1.5 * t);
    y = 30 * sin(t) - 20 * sin(1.5 * t);
    v = 100 - y;
    h = 128 + x;
    point(h*2, v*2);
  }
}

/*
try:
  x = 20 * cos(t) + 20 * cos(3 * t);
  y = 20 * sin(t) - 20 * sin(3 * t);
*/
