configureWindowDropShadowFor: aWindow
	"Configure the drop shadow for the given window."

	Preferences menuAppearance3d
		ifTrue: [super configureWindowDropShadowFor: aWindow]