popUpHaloFor: aMorph event: evt
	self world abandonAllHalos.
	targetOffset _ self position.
	aMorph addHalo: evt
