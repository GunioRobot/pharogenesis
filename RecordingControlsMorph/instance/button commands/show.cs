show
	"Show my samples in a WaveEditor."

	| ed w |
	recorder verifyExistenceOfRecordedSound ifFalse: [^ self].
	recorder pause.
	ed _ WaveEditor new.
	ed data: recorder condensedSamples.
	ed samplingRate: recorder samplingRate.
	w _ self world.
	w activeHand
		ifNil: [w addMorph: ed]
		ifNotNil: [w activeHand attachMorph: ed].

