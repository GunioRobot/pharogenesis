showColorPalette: evt

	| pp myEvt |
	colorMemory align: colorMemory bounds topRight 
			with: colorMemoryThin bounds topRight.
	self addMorphFront: colorMemory.
	"Be sure it gets a mouseEnter: and a mouseLeave:, even if mouse leaves on the next cycle." 
	pp _ (colorMemory bounds insetBy: 1@1) pointNearestTo: evt cursorPoint.
			"so it will be inside"
	myEvt _ evt copy setCursorPoint: pp.
	evt hand handleMouseOver: myEvt.