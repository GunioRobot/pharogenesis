systemPaneMenuButtonPressed: event

	| menu |
	menu _ MenuMorph new defaultTarget: self.
	menu addTitle: 'system category'.
	"**these two belong in class pane**"
	menu add: 'select class...' action: #selectClass.
	menu add: 'select recent...' action: #selectRecentClass.
	menu add: 'browse all classes' action: #browseAllClasses.
	menu add: 'spawn selection' action: #spawnSystemCategory.
	menu addLine.
	menu add: 'fileOut' action: #fileOutSystemCategory.
	menu addLine.
	menu add: 'reorganize' action: #editSystemOrganization.
	menu add: 'add selection...' action: #addSystemCategory.
	menu add: 'rename selection...' action: #renameSystemCategory.
	menu add: 'remove selection' action: #removeSystemCategory.
	event hand invokeMenu: menu event: event.
