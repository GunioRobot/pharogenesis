initialize
	super initialize.
	prevMouseDown _ false.
	showAllEnvelopes _ true.
	self editSound: (sound ifNil: [FMSound brass1 copy]).
	soundName ifNil: [soundName _ 'test'].
	sampleDuration _ 250.  sound duration: sampleDuration.
	sound duration: sampleDuration / 1000.0.
	denominator _ 7.
	self extent: 10@10.  "ie the minimum"
