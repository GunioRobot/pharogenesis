reframeTo: newFrame
	"Reframe the receiver to the given screen rectangle.  
	Repaint difference after the change.  "
	| oldBox newBox portRect |
	self uncacheBits.
	oldBox _ self windowBox.
	portRect _ newFrame topLeft + self labelOffset
				corner: newFrame corner.
	self resizeTo: portRect.
	self setLabelRegion.
	newBox _ self windowBox.
	(oldBox areasOutside: newBox) do:
		[:rect | ScheduledControllers restore: rect].
	self displayEmphasized