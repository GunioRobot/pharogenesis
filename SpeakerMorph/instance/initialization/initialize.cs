initialize
"initialize the state of the receiver"
	super initialize.
""
	self addGraphic.
	bufferSize _ 5000.
	buffer _ WriteStream
				on: (SoundBuffer newMonoSampleCount: bufferSize).
	lastConePosition _ 0.
	sound _ SequentialSound new