putUpDesktopMenu: evt
	"Put up the desktop menu"
	^ ((self buildWorldMenu: evt) addTitle: Preferences desktopMenuTitle) popUpAt: evt position forHand: evt hand in: self