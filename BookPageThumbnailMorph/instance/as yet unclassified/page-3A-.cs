page: aMorph

	page _ aMorph.
	self computeThumbnail.
	self setNameTo: aMorph externalName.
	page fullReleaseCachedState.
