costume: aMorph
	"Make aMorph be the receiver's current costume"
	| itsBounds |
	costume == aMorph ifTrue: [^ self].
	((costume isKindOf: SketchMorph) and: [(aMorph isKindOf: SketchMorph)])
		ifTrue:
			[^ costume wearCostume: aMorph].

	self costumeDictionary
		at: aMorph formalCostumeName
		put: (aMorph fullCopy costumee: nil).
	costume ifNotNil:
		[itsBounds _ costume bounds.
		costume pasteUpMorph replaceSubmorph: costume topRendererOrSelf by: aMorph.
		aMorph position: itsBounds origin.
		aMorph actorState: costume actorState.
		aMorph setNameTo: costume externalName].
	aMorph costumee: self.
	costume _ aMorph.
	aMorph arrangeToStartStepping