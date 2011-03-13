invokeWorldMenu: evt
	| menu |
	Utilities bringFlapsToFront.
	evt isMouse ifTrue:[
		evt yellowButtonPressed
			ifTrue: [^ self yellowButtonClickOnDesktopWithEvent: evt].
		evt shiftPressed ifTrue:[^self findWindow: evt]].
	"put put screen menu"
	menu _ self buildWorldMenu: evt.
	menu addTitle: Preferences desktopMenuTitle.
	menu popUpEvent: evt in: self