syllable: aSyllable
	super syllable: aSyllable.

	syllable events do: [ :each | each duration: (self inherentDurationAt: each phoneme) - (self lowerDurationAt: each phoneme)].
	self rule4; rule5; rule9a; rule9b; rule10