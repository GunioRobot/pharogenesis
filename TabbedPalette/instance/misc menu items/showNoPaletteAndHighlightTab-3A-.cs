showNoPaletteAndHighlightTab: aTab

	| oldTab morphToInstall aSketchEditor |
	oldTab _ tabsMorph highlightedTab.
	(oldTab notNil and: [(morphToInstall _ oldTab morphToInstall) isKindOf: PaintBoxMorph])
		ifTrue:
			[(aSketchEditor _ self world submorphOfClass: SketchEditorMorph) ifNotNil:
				[aSketchEditor cancelOutOfPainting].
			morphToInstall delete].

	currentPage ifNotNil: [currentPage delete].
	currentPage _ nil.
	submorphs size > 1 ifTrue: "spurious submorphs, yecch"
		[(submorphs copyFrom: 2 to: submorphs size) do: [:m | m delete]].
	tabsMorph highlightTab: aTab