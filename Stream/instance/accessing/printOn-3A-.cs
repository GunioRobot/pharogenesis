printOn: stream

	super printOn: stream.
	stream space.
	self contents printOn: stream.
