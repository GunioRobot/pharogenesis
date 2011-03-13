projectMenu
	| menu |
	menu := MenuMorph new defaultTarget: self.
	self createMenuItem: {'open...'. nil. MenuIcons smallOpenIcon} on: menu.
	self createMenuItem: {'windows...'. nil. MenuIcons smallWindowIcon} on: menu.
	menu addLine.
	
	self createMenuItem: {'find any file'. 'Import a file into Squeak'. MenuIcons smallOpenIcon} on: menu.
	self createMenuItem: {'object catalog (o)'. 'A tool for finding and obtaining many kinds of objects'. MenuIcons smallObjectCatalogIcon} on: menu.
	menu addLine.
	self createMenuItem: {'view objects hierarchy'. 'A tool for discovering the objects and the relations between them'. MenuIcons smallObjectsIcon} on: menu.
	^ menu