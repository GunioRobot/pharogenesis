makeTile
	"Make a tile representing my sound.  Get a sound-name from the user by which the sound is to be known."

	| newStyleTile sndName tile |
	recorder verifyExistenceOfRecordedSound ifFalse: [^ self].
	recorder pause.
	newStyleTile _ true.
	newStyleTile
		ifTrue:
			[sndName _ FillInTheBlank
				request: 'Please name your new sound' translated
				initialAnswer: 'sound' translated.
			sndName isEmpty ifTrue: [^ self].

			sndName _ SampledSound unusedSoundNameLike: sndName.
			SampledSound
				addLibrarySoundNamed: sndName
				samples: recorder condensedSamples
				samplingRate: recorder samplingRate.
			tile _ SoundTile new literal: sndName]
		ifFalse:
			[tile _ InterimSoundMorph new sound: 
				(SampledSound
					samples: recorder condensedSamples
					samplingRate: recorder samplingRate)].

	tile bounds: tile fullBounds.
	tile openInHand