removeAllMorphs
	| oldMorphs myWorld |
	myWorld _ self world.
	(fullBounds notNil or:[myWorld notNil]) ifTrue:[self invalidRect: self fullBounds].
	submorphs do: [:m | myWorld ifNotNil: [ m outOfWorld: myWorld ]. m privateOwner: nil].
	oldMorphs _ submorphs.
	submorphs _ EmptyArray.
	oldMorphs do: [ :m | self removedMorph: m ].
	self layoutChanged.
