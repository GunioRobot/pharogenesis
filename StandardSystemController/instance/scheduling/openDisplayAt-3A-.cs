openDisplayAt: aPoint 
	"Create an area with origin aPoint in which the receiver's scheduled 
	view can be displayed. Make it the active view."

	view align: view viewport center with: aPoint.
	view translateBy:
		(view displayBox amountToTranslateWithin: Display boundingBox).
	status _ #open.
	ScheduledControllers scheduleActive: self