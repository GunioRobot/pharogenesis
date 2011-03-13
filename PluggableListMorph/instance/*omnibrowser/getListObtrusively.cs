getListObtrusively
	| lazy |
	lazy _ self listMorph.
	^ (1 to: lazy getListSize) collect: [:i | lazy getListItem: i].
	