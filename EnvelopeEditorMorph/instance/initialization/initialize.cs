initialize
	super initialize.
	prevMouseDown _ false.
	showAllEnvelopes _ true.
	soundName ifNil: [soundName _ 'test'].
	self editSound: (sound ifNil: [FMSound brass1 copy]).
	sound duration: 0.25.
	denominator _ 7.
	self extent: 10@10.  "ie the minimum"
