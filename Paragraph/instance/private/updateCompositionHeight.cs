updateCompositionHeight
	"Mainly used to insure that intersections with compositionRectangle work." 

	compositionRectangle _ compositionRectangle withHeight:
		(self bottomAtLineIndex: lastLine) - compositionRectangle top.
	(text size ~= 0 and: [(text at: text size) = CR])
		ifTrue: [compositionRectangle _ compositionRectangle withHeight:
					compositionRectangle height + (lines at: lastLine) lineHeight]