chooseNewGraphicIn: aMorph event: evt
	"Used by any morph that can be represented by a graphic"
	| reasonableForms aGraphicalMenu myGraphic |
	reasonableForms _ (SketchMorph allSubInstances collect: [:m | m form]) asOrderedCollection.
	reasonableForms addAll: (Smalltalk imageImports collect: [:f | f]).
	reasonableForms addAll: (BitmapFillStyle allSubInstances collect:[:f| f form]).
	reasonableForms _ reasonableForms asSet asOrderedCollection.
	(reasonableForms includes: (myGraphic _ self form))
		ifTrue:
			[reasonableForms remove: myGraphic].
	reasonableForms addFirst: myGraphic.

	aGraphicalMenu _ GraphicalMenu new initializeFor: self withForms: reasonableForms coexist: true.
	aGraphicalMenu selector: #newForm:forMorph:; argument: aMorph.
	evt hand attachMorph: aGraphicalMenu.