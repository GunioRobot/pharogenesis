pageOfSampleWindowsOfExtent: aPoint
	| aPage aWindow pu |
	aPage _ self newPageForStandardPartsBin.
	aPage extent: aPoint.
	aWindow _ Browser new openAsMorphEditing: nil.
	aWindow setLabel: 'System Browser'.
	aPage addMorphBack: aWindow.
	aWindow _ Workspace new embeddedInMorphicWindowLabeled: 'Workspace'.
	aPage addMorphBack: aWindow.
	aPage addMorphBack: FileList openAsMorph.
	aWindow _ SelectorBrowser new morphicWindow.
	aWindow setLabel: 'Selector Browser'.
	aPage addMorphBack: aWindow.
	aPage addMorphBack: ((pu _ PasteUpMorph newSticky borderInset) embeddedInMorphicWindowLabeled: 'assembly').
	pu color: (Color r: 0.839 g: 1.0 b: 0.935).

	aPage  replaceTallSubmorphsByThumbnails.

	^ aPage