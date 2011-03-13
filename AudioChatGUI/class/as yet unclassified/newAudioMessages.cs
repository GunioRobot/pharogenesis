newAudioMessages

	^NewAudioMessages ifNil: [NewAudioMessages := SharedQueue new].