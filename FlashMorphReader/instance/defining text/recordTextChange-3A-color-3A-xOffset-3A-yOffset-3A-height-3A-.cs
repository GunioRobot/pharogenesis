recordTextChange: fontId color: color xOffset: xOffset yOffset: yOffset height: height

	fontId ifNotNil:[activeFont := fonts at: fontId].
	height ifNotNil:[textHeight := height].
	xOffset ifNotNil:[textOffset := xOffset @ textOffset x].
	yOffset ifNotNil:[textOffset := textOffset x @ yOffset].
	color ifNotNil:[textMorph color: color].