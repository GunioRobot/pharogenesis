mouseMove: evt
	"In the middle of drawing a stroke.  6/11/97 19:51 tk"

	| pt |
	pt _ evt cursorPoint.
	(lastEvent ~~ nil and: [pt = lastEvent cursorPoint]) ifTrue: [^ self].
	self perform: action with: evt.
		"Each action must do invalidRect:"
	lastEvent _ evt.
	false ifTrue: ["So senders will find the things performed here"
		self paint: nil; fill: nil; areaFill: nil; erase: nil; pickup: nil; stamp: nil.
		self rect: nil; ellipse: nil; polygon: nil; line: nil; star: nil].