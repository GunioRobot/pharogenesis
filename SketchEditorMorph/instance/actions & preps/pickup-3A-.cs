pickup: evt
	"Grab a part of the picture (or screen) and store it in a known place.  Note where we started.  Use a rubberband rectangle to show what is being selected."

	| rect oldRect sOrigin priorEvt |

	sOrigin _ self get: #strokeOrigin for: evt.
	rect _ sOrigin rect: evt cursorPoint + (14@14).
	(priorEvt _ self get: #lastEvent for: evt) == nil ifFalse: [
			"Last draw will stick out, must erase the area"
			oldRect _ sOrigin rect: priorEvt cursorPoint + (14@14).
			self restoreRect: (oldRect insetBy: -2)].
	formCanvas frameAndFillRectangle: (rect insetBy: -2) fillColor: Color transparent
		borderWidth: 2 borderColor: Color gray.
	self invalidRect: (rect insetBy: -2).