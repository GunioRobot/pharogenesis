removeActiveMorph: aMorph
	| newActive newPassive |
	aMorph visible: false atFrame: frame.
	newActive _ (activeMorphs at: aMorph id) copyWithout: aMorph.
	newPassive _ (passiveMorphs at: aMorph id ifAbsent:[#()]) copyWith: aMorph.
	activeMorphs at: aMorph id put: newActive.
	passiveMorphs at: aMorph id put: newPassive.
	^aMorph