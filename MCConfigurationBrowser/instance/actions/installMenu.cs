installMenu

	| menu |
	menu := MenuMorph new defaultTarget: self.
	menu add: 'load packages' action: #load.
	menu add: 'merge packages' action: #merge.
	menu add: 'upgrade packages' action: #upgrade.
	menu popUpInWorld.