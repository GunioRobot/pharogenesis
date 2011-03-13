removeAllMorphs
	| myWorld |
	myWorld _ self world.
	(fullBounds notNil or:[self isInWorld]) ifTrue:[self invalidRect: self fullBounds].
	submorphs do: [:m | m outOfWorld: myWorld; privateOwner: nil].
	submorphs _ EmptyArray.
	self layoutChanged.
