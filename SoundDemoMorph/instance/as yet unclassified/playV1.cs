playV1

	soundColumn submorphs size < 1 ifTrue: [^ self].
	self setTimbreFromTile: (soundColumn submorphs at: 1).
	(SampledSound bachFugueVoice1On: SampledSound new) play.
