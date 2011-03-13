helpMenu
	"Build the help menu for the world."
	|  menu |
  	menu := self menu: 'Help'.
	self fillIn: menu from: {
               {'Command-key help'. { Utilities . #openCommandKeyHelp}. 'summary of keyboard shortcuts.'}
	}.
	^menu

