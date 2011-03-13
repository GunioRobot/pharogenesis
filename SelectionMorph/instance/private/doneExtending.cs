doneExtending

	otherSelection ifNotNil:
		[selectedItems _ otherSelection selectedItems , selectedItems.
		otherSelection delete.
		self setOtherSelection: nil].
	self changed.
	self layoutChanged.
	super privateBounds:
		((Rectangle merging: (selectedItems collect: [:m | m fullBounds]))
			expandBy: 8).
	self changed.
	self addHalo.