eventsFromString: aString
	| clause |
	clause _ self clauseFromString: aString.
	clause phrases do: [ :each | each lastSyllable events add: (PhoneticEvent new phoneme: self phonemes silence; duration: 0.1)].
	clause lastSyllable events last duration: 0.5.
	visitors do: [ :each | each speaker: self. clause accept: each].
	clause eventsDo: [ :each | each loudness: self loudness].
	^ clause events