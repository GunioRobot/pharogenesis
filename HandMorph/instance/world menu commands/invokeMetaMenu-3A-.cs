invokeMetaMenu: evt
	"Invoke the meta menu. If the hand is over the background, the world menu is presented. If it is over a morph, a menu of operations for that morph is presented. Each menu entry contains a string to be presented in the menu and a selector. If the selector takes an argument, the mouse-down event that invoked the menu is passed as an argument. This lets the command know which hand invoked it in order to do things like attaching the result of the command to that hand.

If the hand is over the background and the shift key is pressed, the find-window menu is immediately put up.

If the hand is over the background but the yellow button was pressed, an alternate menu, which individual users are encouraged to personalize, is put up -- see HandMorph.yellowButtonClickOnDesktopWithEvent:"

	| menu |
	Preferences noviceMode ifTrue: [^ self].

	"if carrying morphs, just drop them"
	self hasSubmorphs ifTrue: [^ self dropMorphsEvent: evt].

	targetOffset _ menuTargetOffset _ self position.
	argument _ self argumentOrNil.
	argument == nil
		ifTrue:
			[Utilities bringFlapsToFront.
			evt yellowButtonPressed
				ifTrue: [^ self yellowButtonClickOnDesktopWithEvent: evt].

			evt shiftPressed
				ifFalse:
					["put put screen menu"
					menu _ self buildWorldMenu.
					menu addTitle: 'World']
				ifTrue:
					[^ self findWindow]]
		ifFalse:
			[menu _ self buildMorphMenuFor: argument.
			menu addTitle: argument class name].
	self invokeMenu: menu event: evt.
