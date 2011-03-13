changesMenu: m
	"Answer the changes menu."

	|menu|
	menu := self newMenu
		addTitle: 'Changes'
		icon: MenuIcons smallCopyIcon.		
	menu
		addToggle: 'Browse class...' translated
		target: self
		selector: #browseClass
		getStateSelector: nil
		enablementSelector: #selectionHasAcutalClass.
	menu lastItem
	 	font: self theme menuFont;
		icon: Browser taskbarIcon.
	menu addLine.
	menu
		addToggle: 'Versions...' translated
		target: self
		selector: #browseVersions
		getStateSelector: nil
		enablementSelector: #selectionIsMethodChange.
	menu lastItem
	 	font: self theme menuFont;
		icon: MenuIcons smallJustifiedIcon.	
	menu
		addToggle: 'Senders...' translated
		target: self
		selector: #browseSenders
		getStateSelector: nil
		enablementSelector: #selectionIsMethodChange.
	menu lastItem
	 	font: self theme menuFont;
		icon: MenuIcons smallForwardIcon.	
	menu
		addToggle: 'Implementors...' translated
		target: self
		selector: #browseImplementors
		getStateSelector: nil
		enablementSelector: #selectionIsMethodChange.
	menu lastItem
	 	font: self theme menuFont;
		icon: MenuIcons smallDoItIcon.	
	menu
		addToggle: 'Install incoming version' translated
		target: self
		selector: #loadMethodSelection
		getStateSelector: nil
		enablementSelector: #selectionIsMethodChange.
	menu lastItem
	 	font: self theme menuFont;
		icon: MenuIcons smallUpdateIcon.
	^menu