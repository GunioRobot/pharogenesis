drawOn: aCanvas

	| foregroundColor backgroundColor thickness hThickness vThickness hOffset vOffset |
	foregroundColor _ highlighted ifTrue: [Color white] ifFalse: [color].
	backgroundColor _ color muchDarker.
	hThickness _ self height * 0.1.
	vThickness _ self width * 0.1.
	thickness _ hThickness min: vThickness.
	vOffset _ ((hThickness - thickness) // 2) max: 0.
	hOffset _ ((vThickness - thickness) // 2) max: 0.
	aCanvas fillRectangle: self bounds color: backgroundColor.
	"added to show the minus sign"
	(digit asString = '-') ifTrue: [digit _ 10].
	HSegmentOrigins with: (HSegments at: digit+1) do:
		[:o :isLit |
		aCanvas
			fillRectangle: (Rectangle
				origin: (self position + (0@vOffset) + (o * self extent)) rounded
				extent: ((self width * 0.6) @ thickness) rounded)
			color: (isLit ifTrue: [foregroundColor] ifFalse: [backgroundColor])].
	VSegmentOrigins with: (VSegments at: digit+1) do:
		[:o :isLit |
		aCanvas
			fillRectangle: (Rectangle
				origin: (self position + (hOffset@0) + (o * self extent)) rounded
				extent: (thickness @ (self height * 0.25)) rounded)
			color: (isLit ifTrue: [foregroundColor] ifFalse: [backgroundColor])].
