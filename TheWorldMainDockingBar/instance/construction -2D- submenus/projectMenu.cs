projectMenu
	| menu |
	menu := MenuMorph new defaultTarget: self.
	""
	Preferences noviceMode
		ifFalse: [""
			self createMenuItem: {'open...'. nil. MenuIcons smallOpenIcon} on: menu.
			self createMenuItem: {'windows...'. nil. MenuIcons smallWindowIcon} on: menu.
			menu addLine].
	""
	self createMenuItem: {'previous project'. 'Return to the most recently visited project'. MenuIcons smallBackIcon} on: menu.
	self createMenuItem: {'jump to project...'. 'Put up a list of all projects, letting me choose one to go to'. MenuIcons smallJumpIcon} on: menu.
	self createMenuItem: {'next project'. 'Go to next project'. MenuIcons smallForwardIcon} on: menu.
	menu addLine.
	self createMenuItem: {'find any file'. 'Import a file into Squeak'. MenuIcons smallOpenIcon} on: menu.
	self createMenuItem: {'find a project'. 'Open a project into Squeak'. MenuIcons smallLoadProjectIcon} on: menu.
	menu addLine.
	self createMenuItem: {'new project'. 'Start a new project'. MenuIcons smallProjectIcon} on: menu.
	self createMenuItem: {'make new drawing'. 'Make a painting'. MenuIcons smallPaintIcon} on: menu.
	self createMenuItem: {'object catalog (o)'. 'A tool for finding and obtaining many kinds of objects'. MenuIcons smallObjectCatalogIcon} on: menu.
	menu addLine.
	self createMenuItem: {'object from paste buffer'. 'Create a new object from paste buffer'. MenuIcons smallPasteIcon} on: menu.
	Preferences useUndo
		ifTrue: [""
			Preferences infiniteUndo
				ifTrue: [""
					menu
						addUpdating: #undoMenuWording
						target: self commandHistory
						action: #undoLastCommand.
					menu
						addUpdating: #redoMenuWording
						target: self commandHistory
						action: #redoNextCommand]
				ifFalse: [""
					menu
						addUpdating: #undoOrRedoMenuWording
						target: self commandHistory
						action: #undoOrRedoCommand]].
	menu addLine.
	self createMenuItem: {'view objects hierarchy'. 'A tool for discovering the objects and the relations between them'. MenuIcons smallObjectsIcon} on: menu.
	menu addLine.
	self createMenuItem: {'publish project'. 'Publish the current project'. MenuIcons smallPublishIcon} on: menu.
	""
	^ menu