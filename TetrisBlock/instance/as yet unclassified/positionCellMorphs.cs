positionCellMorphs

	(shapeInfo atWrap: angle) withIndexDo: [ :each :index |
		(submorphs at: index)
			position: (board originForCell: baseCellNumber + each)
	].
	fullBounds _ nil.
	self changed.
	 
