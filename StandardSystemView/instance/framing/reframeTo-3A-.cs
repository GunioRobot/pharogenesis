reframeTo: newFrame
	"Reframe the receiver to the given screen rectangle.  1/26/96 sw
	Repaint difference after the change.  5/8/96 di"
	| oldBox newBox portRect |
	self uncacheBits.
	oldBox _ self windowBox.
	portRect _ newFrame topLeft + (0@labelFrame height)
				corner: newFrame corner.
	self window: self window viewport: portRect.
	self setLabelRegion.
	newBox _ self windowBox.
	(oldBox areasOutside: newBox) do:
		[:rect | ScheduledControllers restore: rect].
	self displayEmphasized