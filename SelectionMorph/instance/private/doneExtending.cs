doneExtending

	otherSelection ifNotNil:
		[selectedItems _ otherSelection selectedItems , selectedItems.
		otherSelection delete.
		self setOtherSelection: nil].
	self changed; layoutChanged.
	super privateBounds:
		((Rectangle merging: (selectedItems collect: [:m | m bounds]))
			expandBy: 8).
	self changed.
	self addHalo.