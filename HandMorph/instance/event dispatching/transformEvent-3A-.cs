transformEvent: evt
	"Transform the given event by the transform recorded when the mouse went down."

	^ evt transformedBy: eventTransform
