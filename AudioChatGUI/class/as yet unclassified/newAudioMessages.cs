newAudioMessages

	^NewAudioMessages ifNil: [NewAudioMessages _ SharedQueue new].