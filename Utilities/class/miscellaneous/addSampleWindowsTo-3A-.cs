addSampleWindowsTo: aPage
	"Add windows representing a browser, a workspace, etc., to aPage"
	|  aWindow pu |
	aWindow _ Browser new openAsMorphEditing: nil.
	aWindow setLabel: 'System Browser'.
	aPage addMorphBack: aWindow applyModelExtent.
	aWindow _ PackageBrowser new openAsMorphEditing: nil.
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
	aPage addMorphBack: ((pu _ PasteUpMorph newSticky borderInset) embeddedInMorphicWindowLabeled: 'assembly').
	pu color: (Color r: 0.839 g: 1.0 b: 0.935)