testMenuHideShowMenu
	self should: [interface isMenuBarVisible: 1].
	interface hideMenuBar: 1.
	self should: [(interface isMenuBarVisible: 1) not].
	interface showMenuBar: 1.
	self should: [interface isMenuBarVisible: 1].
	interface drawMenuBar: 1.
	