sortTabsFor: aTabbedPalette
	| actualTabs |
	actualTabs _ aTabbedPalette tabMorphs.
	self book: aTabbedPalette morphsToSort:
		(actualTabs collect: [:aTab | aTab sorterToken]).
	pageHolder color: aTabbedPalette tabsMorph color.
 
	self position: aTabbedPalette position.
	pageHolder extent: self extent.
	self setNameTo: 'Tab Sorter for ', aTabbedPalette externalName.
	aTabbedPalette owner addMorphFront: self