showMenu: evt
	| menu |
	menu _ MenuMorph new.
	menu add: 'show code' target: self selector: #showCode.
	menu add: 'try out' target: self selector: #try.
	self rootTile isMethodNode ifTrue:
		[menu addLine.
		menu add: 'accept method' target: self selector: #accept].
	menu popUpAt: evt hand position forHand: evt hand in: World.



