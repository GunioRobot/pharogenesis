desktopColor
	"Answer the desktop color. Initialize it if necessary."
	
	DesktopColor == nil ifTrue: [DesktopColor _ Color gray].
	^ DesktopColor
