playV2

	soundColumn submorphs size < 2 ifTrue: [^ self].
	self setTimbreFromTile: (soundColumn submorphs at: 2).
	SampledSound bachFugueVoice2 playSilentlyUntil: 4.8; resumePlaying.
