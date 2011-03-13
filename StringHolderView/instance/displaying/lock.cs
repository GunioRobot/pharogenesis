lock
	"Refer to the comment in view|lock.  Must do at least what display would do to lock the view."
	(self isUnlocked and: [self insetDisplayBox ~= displayContents clippingRectangle])
		ifTrue:  "Recompose the text if the window changed"
				[self positionDisplayContents. 
				(self controller isKindOf: ParagraphEditor)
					ifTrue: [controller recomputeSelection]].
	super lock