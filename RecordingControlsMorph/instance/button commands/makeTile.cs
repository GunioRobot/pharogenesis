makeTile

	| newStyleTile sndName tile |
	recorder pause.
	newStyleTile _ true.
	newStyleTile
		ifTrue: [
			sndName _ FillInTheBlank
				request: 'Please enter a name this sound'
				initialAnswer: 'sound'.
			sndName isEmpty ifTrue: [^ self].

			sndName _ SampledSound unusedSoundNameLike: sndName.
			SampledSound
				addLibrarySoundNamed: sndName
				samples: recorder condensedSamples
				sampleRate: recorder samplingRate.
			tile _ SoundTile new literal: sndName]
		ifFalse: [
			tile _ InterimSoundMorph new sound: 
				(SampledSound
					samples: recorder condensedSamples
					samplingRate: recorder samplingRate)].

	self world hands first attachMorph: tile.
