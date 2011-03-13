bringUpToDate
	"Make certain, if the receiver is an object-reference tile, that it shows the current external name of the object, which may just have changed.  This only applies to the Player regime." 

	| newLabel |
		(type == #objRef and: [actualObject isKindOf: Player]) ifTrue:
		[newLabel _ actualObject externalName.
		self isPossessive ifTrue:
			[newLabel _ newLabel, '''s'].
		self line1: newLabel]