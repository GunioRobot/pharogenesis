fillOval: rect
	| centerX centerY nextY yBias xBias outer nextOuterX |
	rect area <= 0 ifTrue: [^ self].
	height _ 1.
	yBias _ rect height odd ifTrue: [0] ifFalse: [-1].
	xBias _ rect width odd ifTrue: [1] ifFalse: [0].
	centerX _ rect center x.
	centerY _ rect center y.
	outer _ EllipseMidpointTracer new on: rect.
	nextY _ rect height // 2.
	[nextY > 0] whileTrue:[
		nextOuterX _ outer stepInY.
		width _ (nextOuterX bitShift: 1) + xBias.
		destX _ centerX - nextOuterX.
		destY _ centerY - nextY.
		self copyBits.
		destY _ centerY + nextY + yBias.
		self copyBits.
		nextY _ nextY - 1.
	].
	destY _ centerY.
	height _ 1 + yBias.
	width _ rect width.
	destX _ rect left.
	self copyBits.
