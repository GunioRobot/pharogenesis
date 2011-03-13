addMorphInLayer: aMorph
	super addMorphInLayer: aMorph.
	aMorph isFlapOrTab ifFalse:[self bringFlapTabsToFront].