updateMouseDownTransform
	"To help with, eg, autoscrolling"

	mouseDownMorph
		ifNil: [eventTransform _ MorphicTransform identity]
		ifNotNil: [eventTransform _ mouseDownMorph transformFrom: self].

