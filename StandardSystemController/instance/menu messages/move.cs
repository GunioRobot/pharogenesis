move
	"Ask the user to designate a new origin position for the receiver's view.
	6/10/96 sw: tell the view that it has moved"

	| oldBox | 
	oldBox := view windowBox.
	view uncacheBits.
	view align: view windowBox topLeft
		with: view chooseMoveRectangle topLeft.
	view displayEmphasized.
	view moved.  "In case its model wishes to take note."
	(oldBox areasOutside: view windowBox) do:
		[:rect | ScheduledControllers restore: rect]