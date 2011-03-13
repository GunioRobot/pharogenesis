putUpWorldMenu: evt
	"Put up a menu in response to a click on the desktop, triggered by evt."

	| menu |
	self bringTopmostsToFront.
	"put up screen menu"
	menu := self buildWorldMenu: evt.
	menu addTitle: Preferences desktopMenuTitle translated.
	menu popUpEvent: evt in: self.
	^ menu