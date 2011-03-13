reset

	super reset.
	converter ifNil: [
		converter := UTF8TextConverter new.
	].
