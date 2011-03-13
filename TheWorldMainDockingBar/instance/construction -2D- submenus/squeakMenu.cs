squeakMenu
	| menu |
	menu := MenuMorph new defaultTarget: self.
	Preferences readOnlyMode ifFalse:[
		self createMenuItem: {'save'. 'Save the current state of Squeak on disk'. MenuIcons smallSaveIcon} on: menu.
		self createMenuItem: {'save as...'. 'Save the current state of Squeak on disk under a new name'. MenuIcons smallSaveAsIcon} on: menu.
		self createMenuItem: {'save as new version'. 'Save the current state of Squeak on disk under a version-stamped name'. MenuIcons smallSaveAsIcon} on: menu.
		menu addLine.
		self createMenuItem: {'save and quit'. 'Save the current state of Squeak on disk, and quit out of Squeak'. MenuIcons smallQuitIcon} on: menu].
	self createMenuItem: {'quit'. 'Quit out of Squeak'. MenuIcons smallQuitIcon} on: menu.
	^ menu