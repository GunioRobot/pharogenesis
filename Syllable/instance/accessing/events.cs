events
	^ events ifNil: [events _ CompositeEvent new addAll: (self phonemes collect: [ :each | PhoneticEvent new phoneme: each; duration: 0.080]); yourself]