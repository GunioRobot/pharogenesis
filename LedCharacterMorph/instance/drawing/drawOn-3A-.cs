drawOn: aCanvas 
	| foregroundColor backgroundColor thickness hThickness vThickness hOffset vOffset bOrigin i |
	i _ 0.
	foregroundColor _ highlighted
				ifTrue: [Color white]
				ifFalse: [color].
	backgroundColor _ color darker darker darker.
	hThickness _ self height * 0.1.
	vThickness _ self width * 0.1.
	thickness _ hThickness min: vThickness.
	vOffset _ hThickness - thickness // 2 max: 0.
	hOffset _ vThickness - thickness // 2 max: 0.
	aCanvas fillRectangle: self bounds color: backgroundColor.
	CHSegmentOrigins with: (CHSegments at: char + 1)
		do: [:o :isLit | aCanvas fillRectangle: (Rectangle origin: (self position + (0 @ vOffset) + (o * self extent)) rounded extent: (self width * 0.6 @ thickness) rounded)
				color: (isLit
						ifTrue: [foregroundColor]
						ifFalse: [backgroundColor])].
	CVSegmentOrigins with: (CVSegments at: char + 1)
		do: [:o :isLit | aCanvas fillRectangle: (Rectangle origin: (self position + (hOffset @ 0) + (o * self extent)) rounded extent: (thickness @ (self height * 0.25)) rounded)
				color: (isLit
						ifTrue: [foregroundColor]
						ifFalse: [backgroundColor])].
	TSegments with: (DSegments at: char + 1)
		do: 
			[:tOrigin :isLit | 
			i _ i + 1.
			bOrigin _ BSegments at: i.
			aCanvas
				line: self position x - hOffset + (self width * tOrigin x) @ (self position y - vOffset + (self height * tOrigin y))
				to: self position x + hOffset + (self width * bOrigin x) @ (self position y + vOffset + (self height * bOrigin y))
				width: thickness + 1 // 1.25
				color: (isLit
						ifTrue: [foregroundColor]
						ifFalse: [Color transparent])]