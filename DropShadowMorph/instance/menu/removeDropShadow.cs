removeDropShadow
	| hadHalo first |
	(hadHalo _ self hasHalo) ifTrue: [self halo delete].
	first _ self firstSubmorph.
	owner addAllMorphs: self submorphs.
	hadHalo ifTrue: [first addHalo].
	self delete
