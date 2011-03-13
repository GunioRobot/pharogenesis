newStandardPartsBin
	| aPartsContainer aPage aSize |
	aSize _ 340 @ 160.
	aPartsContainer _ BookMorph new color: Color blue veryMuchLighter.
	aPartsContainer borderWidth: 2.
	aPartsContainer removeEverything.
	aPartsContainer openToDragNDrop: false.
	aPartsContainer addMorphBack: (aPartsContainer makeMinimalControlsWithColor: Color transparent title: '    Parts Bin    ').

	self classNamesForStandardPartsBin do:
		[:aList |
			aPage _ self newPageForStandardPartsBin.
			aList do:
				[:sym | aPage addMorphBack: (Smalltalk at: sym) authoringPrototype].
			aPage fixLayout.
			aPartsContainer insertPage: aPage pageSize: aSize].
"
	aBrowser _ Browser new openAsMorphEditing: nil.
	aPage _ self newPageForStandardPartsBin.
	aBrowser extent: (200 @ 140); setLabel: 'Browser'.
	aPage addMorphBack: aBrowser.
	aPage markAsPartsDonor.
	aPartsContainer insertPage: aPage pageSize: aSize."

"	#(valueTiles booleanTiles arithmeticTiles) do:
		[:aSym |
			aPage _ self newPageForStandardPartsBin.
			(self perform: aSym) do:
				[:aTile | aPage addMorphBack: aTile markAsPartsDonor].
			aPage fixLayout.
			self coloredTilesEnabled ifFalse:
				[aPage makeAllTilesGreen].
			aPartsContainer insertPage: aPage pageSize: aSize]."

	aPartsContainer goToPage: 1.
^ aPartsContainer
