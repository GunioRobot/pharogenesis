pickup: evt
	"Grab a part of the picture (or screen) and store it in a known place.  Note where we started.  Use a rubberband rectangle to show what is being selected."

	| rect oldRect |
	rect _ strokeOrigin rect: evt cursorPoint + (14@14).
	lastEvent == nil ifFalse: [
			"Last draw will stick out, must erase the area"
			oldRect _ strokeOrigin rect: lastEvent cursorPoint + (14@14).
			self restoreRect: (oldRect insetBy: -2)].
	formCanvas frameAndFillRectangle: (rect insetBy: -2) fillColor: Color transparent
		borderWidth: 2 borderColor: Color gray.
	self invalidRect: (rect insetBy: -2).