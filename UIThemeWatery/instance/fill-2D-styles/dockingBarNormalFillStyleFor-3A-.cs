dockingBarNormalFillStyleFor: aToolDockingBar
	"Return the normal docking bar fillStyle for the given bar."
		
	^(BitmapFillStyle fromForm: self stripesForm)
		origin: aToolDockingBar topLeft