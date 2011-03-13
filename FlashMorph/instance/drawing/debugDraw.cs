debugDraw
	| vis canvas m |
	vis := self visible.
	self visible: true.
	canvas := BalloonCanvas on:Display.
	m := MatrixTransform2x3 withScale: 0.05.
	m offset: (self fullBounds origin // 20) negated.
	canvas transformBy: m.
	self fullDrawOn: canvas.
	self visible: vis.