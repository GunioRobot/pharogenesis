playAll
	| snd |
	soundColumn submorphs isEmpty
		ifTrue: [^ self].
	self setTimbreFromTile: soundColumn submorphs first.
	snd _ SampledSound bachFugueVoice1On: SampledSound new.
	soundColumn submorphs size >= 2
		ifTrue: [""self setTimbreFromTile: soundColumn submorphs second.
			snd _ snd
						+ (AbstractSound bachFugueVoice2On: SampledSound new)].
	soundColumn submorphs size >= 3
		ifTrue: [""self setTimbreFromTile: soundColumn submorphs third.
			snd _ snd
						+ (AbstractSound bachFugueVoice3On: SampledSound new)].
	snd play