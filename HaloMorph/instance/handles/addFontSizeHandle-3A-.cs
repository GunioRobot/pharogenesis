addFontSizeHandle: haloSpec
	(innerTarget isKindOf: TextMorph) ifTrue:
		[self addHandle: haloSpec
				on: #mouseDown send: #chooseFont to: innerTarget]
