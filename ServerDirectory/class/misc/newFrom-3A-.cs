newFrom: aSimilarObject
	"Must copy the urlObject, so they won't be shared"

	| inst |
	inst _ super newFrom: aSimilarObject.
	inst urlObject: aSimilarObject urlObject copy.
	^ inst