initialize
	super initialize.
	prevMouseDown _ false.
	playRemaining _ 0.
	showAllEnvelopes _ true.
	self editSound: (sound ifNil: [FMSound brass1 copy]).
	soundName ifNil: [soundName _ 'test'].
	playMode ifNil: [playMode _ #afterEdits].
	whatToPlay _ #playShortNote.
	samplePitch _ #c5.
	denominator _ 7.
	self extent: 400@300.
