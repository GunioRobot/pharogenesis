setStackText: textOrString
	shortStackPane scroller removeAllMorphs; addMorph:
		(TextMorph new contents: textOrString asText)