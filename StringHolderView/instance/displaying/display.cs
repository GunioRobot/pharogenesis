display 
	"Refer to the comment in View.display."
	(self isUnlocked and: [self insetDisplayBox ~= displayContents clippingRectangle])
		ifTrue:  "Recompose the text if the window changed"
				[self positionDisplayContents. 
				(self controller isKindOf: ParagraphEditor)
					ifTrue: [controller recomputeSelection]].
	super display