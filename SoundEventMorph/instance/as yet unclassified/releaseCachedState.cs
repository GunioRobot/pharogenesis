releaseCachedState

	super releaseCachedState.
	sound _ sound compressWith: GSMCodec.
