addHalo: evt from: formerHaloOwner
	"Special case if the formerHaloOwner was a wrapper within the receiver"
	self removeAllWrappers. "Get rid of them"
	(formerHaloOwner isKindOf: WonderlandWrapperMorph)
		ifTrue:[^super addHalo: evt] "Add a halo to me"
		ifFalse:[^self addHalo: evt] "Add a halo from pick"