addFontStyleHandle: haloSpec
	(innerTarget isKindOf: TextMorph) ifTrue:
		[self addHandle: haloSpec
				on: #mouseDown send: #chooseStyle to: innerTarget]
