function setup() {
  createCanvas(400, 400);
}

function draw() {
  background(50);
  stroke(255, 165, 0);
  strokeWeight(2);

	// Main drawing logic
	for (let y = -10; y <= 10; y += 0.2) {
	  for (let x = -10; x <= 10; x += 0.3) {
		let r = Math.sqrt(x * x + y * y) * 1.5;
		let f = r === 0 ? 90 : Math.abs(90 * Math.sin(r) / r);
		let a = Math.floor(10 * x + 160 - 5 * y);
		let b = Math.floor(5 * y + 2.5 * x + 93);
		point(a, b - f);
	  }
	}
}