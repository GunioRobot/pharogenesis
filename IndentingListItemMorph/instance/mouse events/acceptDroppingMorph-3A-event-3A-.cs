acceptDroppingMorph: toDrop event: evt. 
	complexContents acceptDroppingObject: toDrop complexContents.
	toDrop delete.
	self clearDropHighlighting.