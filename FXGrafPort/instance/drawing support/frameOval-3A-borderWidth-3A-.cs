frameOval: rect borderWidth: borderWidth
	| centerX centerY nextY yBias xBias wp outer inner nextOuterX nextInnerX fillAlpha |
	rect area <= 0 ifTrue: [^ self].
	height _ 1.
	wp _ borderWidth asPoint.
	yBias _ rect height odd ifTrue: [0] ifFalse: [-1].
	xBias _ rect width odd ifTrue: [1] ifFalse: [0].
	centerX _ rect center x.
	centerY _ rect center y.
	outer _ EllipseMidpointTracer new on: rect.
	inner _ EllipseMidpointTracer new on: (rect insetBy: wp).
	nextY _ rect height // 2.
	1 to: (wp y min: nextY) do:[:i|
		nextOuterX _ outer stepInY.
		width _ (nextOuterX bitShift: 1) + xBias.
		destX _ centerX - nextOuterX.
		destY _ centerY - nextY.
		self copyBits.
		destY _ centerY + nextY + yBias.
		self copyBits.
		nextY _ nextY - 1.
	].
	[nextY > 0] whileTrue:[
		nextOuterX _ outer stepInY.
		nextInnerX _ inner stepInY.
		destX _ centerX - nextOuterX.
		destY _ centerY - nextY.
		width _ nextOuterX - nextInnerX.
		self copyBits.
		destX _ centerX + nextInnerX + xBias.
		self copyBits.
		destX _ centerX - nextOuterX.
		destY _ centerY + nextY + yBias.
		self copyBits.
		destX _ centerX + nextInnerX + xBias.
		self copyBits.
		nextY _ nextY - 1.
	].
	destY _ centerY.
	height _ 1 + yBias.
	width _ wp x.
	destX _ rect left.
	self copyBits.
	destX _ rect right - wp x.
	self copyBits.
