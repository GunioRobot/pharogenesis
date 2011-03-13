text: s bounds: boundsRect font: fontOrNil color: c
	| fontIndex |
	fontIndex := self establishFont: (fontOrNil ifNil: [ TextStyle defaultFont ]).
	self sendCommand: {
		String with: CanvasEncoder codeText.
		s.
		self class encodeRectangle: boundsRect.
		self class encodeInteger: fontIndex.
		self class encodeColor: c
	}