offerGetterTiles: slotName 
	"For a player-type slot, offer to build convenient compound tiles that otherwise would be hard to get"

	| typeChoices typeChosen thePlayerThereNow slotChoices slotChosen getterTiles aCategoryViewer playerGetter |
	typeChoices := Vocabulary typeChoices.
	typeChosen := (SelectionMenu labelList: (typeChoices collect: [:t | t translated]) lines: #() selections: typeChoices) 
				startUpWithCaption: ('Choose the TYPE
of data to get from
{1}''s {2}' translated format: {self externalName. slotName translated}).
	typeChosen isEmptyOrNil ifTrue: [^self].
	thePlayerThereNow := self perform: (Utilities getterSelectorFor: slotName).
	thePlayerThereNow 
		ifNil: [thePlayerThereNow := self presenter standardPlayer].
	slotChoices := thePlayerThereNow slotNamesOfType: typeChosen.
	slotChoices isEmpty 
		ifTrue: [^self inform: 'sorry -- no slots of that type' translated].
	slotChoices _ slotChoices asSortedArray.
	slotChosen := (SelectionMenu labelList: (slotChoices collect: [:t | t translated]) selections: slotChoices) 
				startUpWithCaption: ('Choose the datum
you want to extract from {1}''s {2}' translated format: {self externalName. slotName translated}).
	slotChosen isEmptyOrNil ifTrue: [^self].
	"Now we want to tear off tiles of the form
		holder's valueAtCursor's foo"
	getterTiles := nil.
	aCategoryViewer := CategoryViewer new initializeFor: thePlayerThereNow
				categoryChoice: 'basic'.
	getterTiles := aCategoryViewer 
				getterTilesFor: (Utilities getterSelectorFor: slotChosen)
				type: typeChosen.
	aCategoryViewer := CategoryViewer new initializeFor: self
				categoryChoice: 'basic'.
	playerGetter := aCategoryViewer 
				getterTilesFor: (Utilities getterSelectorFor: slotName)
				type: #Player.
	getterTiles submorphs first acceptDroppingMorph: playerGetter event: nil.	"the pad"	"simulate a drop"
	getterTiles makeAllTilesGreen.
	getterTiles justGrabbedFromViewer: false.
	(getterTiles firstSubmorph)
		changeTableLayout;
		hResizing: #shrinkWrap;
		vResizing: #spaceFill.
	ActiveHand attachMorph: getterTiles