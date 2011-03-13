changesMenu: m
	"Answer the changes menu."

	|menu|
	menu := super changesMenu: m.
	menu addLine.
	menu
		addToggle: 'Keep current version' translated
		target: self
		selector: #keepCurrentVersion
		getStateSelector: nil
		enablementSelector: #selectionIsConflict.
	menu lastItem
	 	font: self theme menuFont;
		icon: MenuIcons smallBackIcon.	
	menu
		addToggle: 'Use incoming version' translated
		target: self
		selector: #useIncomingVersion
		getStateSelector: nil
		enablementSelector: #selectionIsConflict.
	menu lastItem
	 	font: self theme menuFont;
		icon: MenuIcons smallForwardIcon.
	menu
		addToggle: 'Mark as conflict' translated
		target: self
		selector: #markAsConflict
		getStateSelector: nil
		enablementSelector: #selectionIsConflict.
	menu lastItem
	 	font: self theme menuFont;
		icon: MenuIcons smallCancelIcon.
	menu addLine.
	menu
		addToggle: 'Select next conflict' translated
		target: self
		selector: #selectNextConflict
		getStateSelector: nil
		enablementSelector: #notAllConflictsResolved.
	menu lastItem
	 	font: self theme menuFont;
		icon: MenuIcons smallRightFlushIcon.	
	^menu