reset

	super reset.
	converter ifNil: [
		converter _ UTF8TextConverter new.
	].
