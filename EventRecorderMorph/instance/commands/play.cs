play

	self isInWorld ifFalse: [^ self].
	self stop.
	tape ifNil: [^ self].
	tapeStream _ ReadStream on: tape.
	self resumePlayIn: self world.
	self setStatusLight: #nowPlaying.

