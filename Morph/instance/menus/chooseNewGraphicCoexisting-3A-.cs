chooseNewGraphicCoexisting: aBoolean
	"Used by any morph that can be represented by a graphic"
	| reasonableForms replacee aGraphicalMenu myGraphic |
	reasonableForms _ (SketchMorph allSubInstances collect: [:m | m form]) asOrderedCollection.

	reasonableForms addAll: (Smalltalk imageImports collect: [:f | f]).
	reasonableForms _ reasonableForms asSet asOrderedCollection.
	(reasonableForms includes: (myGraphic _ self form))
		ifTrue:
			[reasonableForms remove: myGraphic].
	reasonableForms addFirst: myGraphic.

	aGraphicalMenu _ GraphicalMenu new initializeFor: self withForms: reasonableForms coexist: aBoolean.
	aBoolean
		ifFalse:
			[replacee _ self topRendererOrSelf.
			replacee owner replaceSubmorph: replacee by: aGraphicalMenu]
		ifTrue:
			[self primaryHand attachMorph: aGraphicalMenu]