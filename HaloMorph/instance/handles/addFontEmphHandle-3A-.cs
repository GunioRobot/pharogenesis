addFontEmphHandle: haloSpec
	(innerTarget isKindOf: TextMorph) ifTrue:
		[self addHandle: haloSpec
				on: #mouseDown send: #chooseEmphasisOrAlignment to: innerTarget]
