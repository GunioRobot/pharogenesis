initialize

	super initialize.
	self addGraphic.
	self color: (Color r: 1.0 g: 0.484 b: 0.258).
	bufferSize _ 5000.
	buffer _ WriteStream on: (SoundBuffer newMonoSampleCount: bufferSize).
	lastConePosition _ 0.
	sound _ SequentialSound new.
