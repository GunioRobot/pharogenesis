updateCompositionHeight
	"Mainly used to insure that intersections with compositionRectangle work." 

	compositionRectangle := compositionRectangle withHeight:
		(self bottomAtLineIndex: lastLine) - compositionRectangle top.
	(text size ~= 0 and: [(text at: text size) = CR])
		ifTrue: [compositionRectangle := compositionRectangle withHeight:
					compositionRectangle height + (lines at: lastLine) lineHeight]