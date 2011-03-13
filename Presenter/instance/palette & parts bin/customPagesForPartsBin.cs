customPagesForPartsBin
	| aPage aWindow  pu pageList aClass |
	pageList _ OrderedCollection new.

	pageList add: (aPage _ self newPageForStandardPartsBin).
	aPage addMorphBack: (PasteUpMorph authoringPrototype color: (Color r: 0.96 g: 0.96 b: 0.96)).
	aPage addMorphBack: TabbedPalette authoringPrototype.
	aPage addMorphBack: BookMorph authoringPrototype.
	aPage addMorphBack: ScriptingSystem prototypicalHolder.
	aPage addMorphBack: Morph new previousPageButton markAsPartsDonor.
	aPage addMorphBack: Morph new nextPageButton markAsPartsDonor.

	#(DatumMorph) do:
		[:aName | (aClass _ Smalltalk at: aName ifAbsent: [nil]) ifNotNil:
			[aPage addMorphBack: aClass authoringPrototype]].

	pageList add: (aPage _ self newPageForStandardPartsBin).
	aWindow _ Browser new openAsMorphEditing: nil.
	aWindow setLabel: 'System Browser'.
	aPage addMorphBack: aWindow applyModelExtent.

	aWindow _ PackagePaneBrowser new openAsMorphEditing: nil.
	aWindow setLabel: 'Package Browser'.
	aPage addMorphBack: aWindow applyModelExtent.

	aWindow _ Workspace new embeddedInMorphicWindowLabeled: 'Workspace'.
	aPage addMorphBack: aWindow applyModelExtent.
	aPage addMorphBack: FileList openAsMorph applyModelExtent.

	aPage addMorphBack: DualChangeSorter new morphicWindow applyModelExtent.
	aPage addMorphBack: ChangeSorter new morphicWindow applyModelExtent.

	aWindow _ SelectorBrowser new morphicWindow.
	aWindow setLabel: 'Selector Browser'.
	aPage addMorphBack: aWindow.

	pageList add: (aPage _ self newPageForStandardPartsBin).
	aPage addMorphBack: ScriptingSystem newScriptingSpace.
	aPage addMorphBack: ScriptingSystem scriptControlButtons.
	aPage addMorphBack: TrashCanMorph new.
	aPage addMorphBack: PasteUpMorph authoringPrototype.
	aPage addMorphBack: ((pu _ PasteUpMorph newSticky) embeddedInMorphicWindowLabeled: 'assembly').
	pu color: (Color r: 0.839 g: 1.0 b: 0.935).

	pageList do:[:page | page  replaceTallSubmorphsByThumbnails].

	^ pageList
