removeAllMorphsIn: aCollection
	"greatly speeds up the removal of *lots* of submorphs"
	| set myWorld |
	myWorld _ self world.
	(fullBounds notNil or:[myWorld notNil]) ifTrue:[self invalidRect: self fullBounds].
	aCollection do: [:m | m outOfWorld: myWorld; privateOwner: nil].
	set _ IdentitySet new: aCollection size * 4 // 3.
	aCollection do: [:each | set add: each].
	submorphs _ submorphs reject: [ :each | set includes: each].
	self layoutChanged.
