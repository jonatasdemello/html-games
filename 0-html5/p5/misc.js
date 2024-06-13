// using p5.js

function setup() {
  createCanvas(400, 400);
}

function draw() {
  background(50);
  
  stroke(255, 165, 0);
  strokeWeight(2);
  
  var x=0, y=0, v=0, h=0;
  
  //for (var t=0; t<12.56; t+=.05) {
    
  for (var t=-5.0; t<4.0; t+=0.05) {
    y = Fx(t);
    
    v = (50 - y*4);
    h = (50 + t*8);
    //console.log(v,h);
    
    point (h*4, v*4);
  }
}

function Fx(x) {
  return (x**3 + 3 * x**2 - 6*x - 8)/4;
}

// f(x,y) = Math.sin(x**2) * Math.cos(y**2)
// is { x, y, z = Math.sin(x**2) * Math.cos(y**2) }

// f(x,y) = −(cos⁡(x**2)+cos⁡(y**2))**2

// The equation of a circle is (x − a)2 + (y − b)2 = r2 
// where a and b are the coordinates of the center (a, b) and r is the radius.

// 3d
// f(x,y) = (4 * Math.sin( Math.sqr(x**2 + y**2) ) / Math.sqr(x**2 + y**2)
// 8100 points = { x, y, f(x,y) }
// range: [-9 <= x <= 9] and [-9 <= y <= 9]
