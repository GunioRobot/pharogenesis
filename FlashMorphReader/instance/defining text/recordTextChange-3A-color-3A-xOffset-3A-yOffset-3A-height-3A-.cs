recordTextChange: fontId color: color xOffset: xOffset yOffset: yOffset height: height

	fontId ifNotNil:[activeFont _ fonts at: fontId].
	height ifNotNil:[textHeight _ height].
	xOffset ifNotNil:[textOffset _ xOffset @ textOffset x].
	yOffset ifNotNil:[textOffset _ textOffset x @ yOffset].
	color ifNotNil:[textMorph color: color].