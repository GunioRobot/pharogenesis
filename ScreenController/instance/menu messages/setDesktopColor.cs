setDesktopColor
	"Let the user choose a new color for the desktop.   Based on an idea by Georg Gollmann.   "

	Preferences desktopColor: Color fromUser.
	ScheduledControllers updateGray; restore