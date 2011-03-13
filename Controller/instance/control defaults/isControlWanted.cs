isControlWanted
	"Answer whether the cursor is inside the inset display box (see 
	View|insetDisplayBox) of the receiver's view. It is sent by 
	Controller|controlNextLevel in order to determine whether or not control 
	should be passed to this receiver from the Controller of the superView of 
	this receiver's view."

	^self viewHasCursor