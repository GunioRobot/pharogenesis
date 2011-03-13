setBottom: w
	"Set the bottom coordinate (cartesian sense) of the object as requested"

	| topLeftNow |

	topLeftNow _ self costume cartesianBoundsTopLeft.
	^ self costume bottom: self costume top + topLeftNow y - w
