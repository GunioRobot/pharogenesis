retargetFrom: oldPlayer to: newPlayer
	"Change the receiver so that if formerly it referred to oldPlayer, it refers to newPlayer instead"

	| newLabel |
	(type == #objRef  and: [actualObject == oldPlayer]) ifTrue:
		[actualObject _ newPlayer.
		newLabel _ actualObject externalName.
		self isPossessive ifTrue:
			[newLabel _ newLabel, '''s' translated].
		self line1: newLabel]