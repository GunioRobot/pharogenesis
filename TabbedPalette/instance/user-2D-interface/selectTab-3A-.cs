selectTab: aTab
	| currentPalette morphToInstall oldTab aSketchEditor |
	currentPage ifNotNil:
		[self currentPalette currentPlayerDo:
			[:aPlayer | aPlayer runAllClosingScripts]].
	oldTab _ tabsMorph highlightedTab.
	(oldTab notNil and: [(morphToInstall _ oldTab morphToInstall) isKindOf: PaintBoxMorph])
		ifTrue:
			[(aSketchEditor _ self world submorphOfClass: SketchEditorMorph) ifNotNil:
				[aSketchEditor cancelOutOfPainting].
			morphToInstall delete].

	tabsMorph selectTab: aTab.
	morphToInstall _ aTab morphToInstall.

	(morphToInstall isKindOf: PaintBoxMorph) "special case, maybe generalize this need?"
		ifFalse:
			[self goToPageMorph: morphToInstall]
		ifTrue:
			[self showNoPaletteAndHighlightTab: aTab.
			self world addMorphFront: morphToInstall.
			morphToInstall position: ((self left max: 90) "room for the pop-out-to-left panel"
				@ (tabsMorph bottom))].
	
	(currentPalette _ self currentPalette) ifNotNil:
		[currentPalette layoutChanged.
		currentPalette currentPlayerDo: [:aPlayer | aPlayer runAllOpeningScripts]].
	self snapToEdgeIfAppropriate