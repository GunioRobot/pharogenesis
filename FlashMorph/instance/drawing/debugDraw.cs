debugDraw
	| vis canvas m |
	vis _ self visible.
	self visible: true.
	canvas _ BalloonCanvas on:Display.
	m _ MatrixTransform2x3 withScale: 0.05.
	m offset: (self fullBounds origin // 20) negated.
	canvas transformBy: m.
	self fullDrawOn: canvas.
	self visible: vis.