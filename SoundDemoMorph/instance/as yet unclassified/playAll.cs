playAll

	| snd |
	soundColumn submorphs size < 1 ifTrue: [^ self].
	self setTimbreFromTile: (soundColumn submorphs at: 1).
	snd _ SampledSound bachFugueVoice1On: SampledSound new.

	soundColumn submorphs size >= 2 ifTrue: [
		self setTimbreFromTile: (soundColumn submorphs at: 2).
		snd _ snd + (AbstractSound bachFugueVoice2On: SampledSound new)].

	soundColumn submorphs size >= 3 ifTrue: [
		self setTimbreFromTile: (soundColumn submorphs at: 3).
		snd _ snd + (AbstractSound bachFugueVoice3On: SampledSound new)].

	snd play.
