merging: listOfRects
	"A number of callers of merge: should use this method."
	| topLeft bottomRight |
	topLeft _ bottomRight _ nil.
	listOfRects do:
		[:r | topLeft == nil
			ifTrue: [topLeft _ r topLeft.
					bottomRight _ r bottomRight]
			ifFalse: [topLeft _ topLeft min: r topLeft.
					bottomRight _ bottomRight max: r bottomRight]].
	^ topLeft corner: bottomRight