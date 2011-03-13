reframeTo: newFrame
	"Reframe the receiver to the given screen rectangle.  
	Repaint difference after the change.  "
	| oldBox newBox portRect |
	self uncacheBits.
	oldBox := self windowBox.
	portRect := newFrame topLeft + self labelOffset
				corner: newFrame corner.
	self setWindow: nil.
	self resizeTo: portRect.
	self setLabelRegion.
	newBox := self windowBox.
	(oldBox areasOutside: newBox) do:
		[:rect | ScheduledControllers restore: rect].
	self displayEmphasized