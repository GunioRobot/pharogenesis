mouseUp: evt
	"Do nothing except those that work on mouseUp."

	action == #fill: ifTrue: [
		self perform: action with: evt.
		"Each action must do invalidRect:"
		].
	action == #areaFill: ifTrue: ["old, remove it"
		self perform: action with: evt.
		"Each action must do invalidRect:"
		].
	action == #pickup: ifTrue: [
		self pickupMouseUp: evt].
	lastEvent _ nil.
