createDockingBar
	"Create a docking bar from the receiver's representation"
	| dockingBar |
	dockingBar := DockingBarMorph new.
	dockingBar adhereToTop.
	dockingBar color: ColorTheme current dockingBarColor.
	dockingBar gradientRamp: ColorTheme current  dockingBarGradientRamp.
	dockingBar autoGradient: ColorTheme current dockingBarAutoGradient.
	""
	self fillDockingBar: dockingBar.
	""
	^ dockingBar