setTop: w
	"Set the top coordinate as indicated, using cartesian sense"

	| topLeftNow |
	topLeftNow _ self costume cartesianBoundsTopLeft.
	^ self costume top: self costume top + topLeftNow y - w