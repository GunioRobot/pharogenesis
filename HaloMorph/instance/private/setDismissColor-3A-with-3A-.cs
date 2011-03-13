setDismissColor: evt with: dismissHandle
	"Called on mouseStillDown in the dismiss handle; set the color appropriately."

	| colorToUse |
	evt hand obtainHalo: self.
	colorToUse _  (dismissHandle containsPoint: evt cursorPoint)
		ifFalse:
			[Color red muchLighter]
		ifTrue:
			[Color lightGray].
	dismissHandle color: colorToUse