setLeft: w
	"Set the object's left coordinate as indicated"

	| topLeftNow |
	topLeftNow _ self costume cartesianBoundsTopLeft.
	^ self costume left: self costume left - topLeftNow x + w
