yellowButtonClickOnDesktopWithEvent: evt
	"Put up either the personalized menu or the world menu when the user clicks on the morphic desktop with the yellow button.  The preference 'personalizedWorldMenu' governs which one is used"

	| aMenu |
		Preferences personalizedWorldMenu
			ifFalse:
				[aMenu _ self buildWorldMenu.
				aMenu addTitle: 'World']
			ifTrue:
				[aMenu _ MenuMorph new defaultTarget: self world.
				Preferences personalizeUserMenu: aMenu.
				aMenu addLine.
				aMenu add: 'personalize...' target: Preferences action: #letUserPersonalizeMenu].
	self invokeMenu: aMenu event: evt

