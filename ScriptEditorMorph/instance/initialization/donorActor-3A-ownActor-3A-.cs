donorActor: donorActor ownActor: ownActor
	"The receiver has been cloned as part of cloning an actor; all references within the receiver to the donor actor need to become references to own actor"

	(self allMorphs "copyWithout: self") do:
		[:m | (m isKindOf: TileMorph) ifTrue:
			[m donorActor: donorActor ownActor: ownActor]]