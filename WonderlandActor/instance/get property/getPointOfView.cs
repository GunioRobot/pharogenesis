getPointOfView
	"Returns the object's position and orientation"

	| anArray a3DVector |

	a3DVector _ composite translation.

	anArray _ Array new: 6.
	anArray at: 1 put: (a3DVector x).
	anArray at: 2 put: (a3DVector y).
	anArray at: 3 put: (a3DVector z).

	a3DVector _ composite rotation.
	anArray at: 4 put: (a3DVector x).
	anArray at: 5 put: (a3DVector y).
	anArray at: 6 put: (a3DVector z).

	^ anArray.
