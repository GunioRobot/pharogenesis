chooseNewGraphicCoexisting: aBoolean
	"Allow the user to choose a different form for her form-based morph"

	| reasonableForms replacee aGraphicalMenu myGraphic |
	reasonableForms _ (SketchMorph allInstances
		select:
			[:m | ((m owner isKindOf: SketchEditorMorph) or: [m owner isKindOf: IconicButton]) not]
		thenCollect:
			 [:m | m form]) asSet "eliminate duplicates" asOrderedCollection.

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