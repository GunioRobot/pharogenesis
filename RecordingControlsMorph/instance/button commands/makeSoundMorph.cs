makeSoundMorph

	| m |
	recorder verifyExistenceOfRecordedSound ifFalse: [^ self].

	recorder pause.
	m _ SoundEventMorph new sound: recorder recordedSound.
	self world firstHand attachMorph: m.
