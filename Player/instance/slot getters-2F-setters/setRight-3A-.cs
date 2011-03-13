setRight: w
	"Set the right coordinate to the given value"

	| topLeftNow  |
	topLeftNow _ self costume cartesianBoundsTopLeft.
	^ self costume right: self costume left - topLeftNow x + w
