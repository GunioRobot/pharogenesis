text: t textStyle: ts foreground: foreColor background: backColor fillBlt: blt
	text _ t.
	textStyle _ ts. 
	foregroundColor _ paragraphColor _ foreColor.
	(backgroundColor _ backColor) isTransparent ifFalse:
		[fillBlt _ blt.
		fillBlt fillColor: backgroundColor].
