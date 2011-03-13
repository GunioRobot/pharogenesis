addSampleWindowsTo: aPage
	"Add windows representing a browser, a workspace, etc., to aPage"
	|  aWindow pu |
	aWindow := Browser new openAsMorphEditing: nil.
	aWindow setLabel: 'System Browser'.
	aPage addMorphBack: aWindow applyModelExtent.
	aWindow := PackagePaneBrowser new openAsMorphEditing: nil.
	aWindow setLabel: 'Package Browser'.
	aPage addMorphBack: aWindow applyModelExtent.
	aWindow := Workspace new embeddedInMorphicWindowLabeled: 'Workspace'.
	aPage addMorphBack: aWindow applyModelExtent.
	aPage addMorphBack: FileList openAsMorph applyModelExtent.

	aPage addMorphBack: DualChangeSorter new morphicWindow applyModelExtent.
	aPage addMorphBack: ChangeSorter new morphicWindow applyModelExtent.

	aWindow := SelectorBrowser new morphicWindow.
	aWindow setLabel: 'Selector Browser'.
	aPage addMorphBack: aWindow.
	aPage addMorphBack: ((pu := PasteUpMorph newSticky borderInset) embeddedInMorphicWindowLabeled: 'assembly').
	pu color: (Color r: 0.839 g: 1.0 b: 0.935)