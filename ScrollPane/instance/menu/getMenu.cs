getMenu
	"Answer the menu for this text view, supplying an empty menu to be filled in. If the menu selector takes an extra argument, pass in the current state of the shift key."
	^ self getMenu: Sensor leftShiftDown