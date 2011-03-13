loadMenu

	| menu |
	menu := MenuMorph new defaultTarget: self.
	menu add: 'update from image' action: #updateFromImage.
	menu add: 'update from repositories' action: #updateFromRepositories.
	menu popUpInWorld.
