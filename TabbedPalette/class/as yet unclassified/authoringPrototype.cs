authoringPrototype
	| aTabbedPalette aBook aTab |
	aTabbedPalette _ self new markAsPartsDonor.
	aTabbedPalette pageSize: 200 @ 300.
	aTabbedPalette tabsMorph highlightColor: Color red regularColor: Color blue.
	aTabbedPalette addMenuTab.

	aBook _ BookMorph new setNameTo: 'one'; pageSize: aTabbedPalette pageSize.
	aBook color: Color blue muchLighter.
	aBook removeEverything; insertPage; showPageControls.
	aBook currentPage addMorphBack: (SketchMorph withForm: ScriptingSystem squeakyMouseForm).
	aTab _ aTabbedPalette addTabForBook: aBook.

	aBook _ BookMorph new setNameTo: 'two'; pageSize: aTabbedPalette pageSize.
	aBook color: Color red muchLighter.
	aBook removeEverything; insertPage; showPageControls.
	aBook currentPage addMorphBack: CurveMorph authoringPrototype.
	aTabbedPalette addTabForBook: aBook.

	aTabbedPalette selectTab: aTab.

	aTabbedPalette beSticky.
	^ aTabbedPalette