restore: aRectangle without: aView
	"Restore all windows visible in aRectangle"
	Display deferUpdates: true.
	self restore: aRectangle below: 1 without: aView.
	Display deferUpdates: false; forceToScreen: aRectangle