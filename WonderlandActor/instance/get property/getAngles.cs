getAngles
	"Return the object's current orientation in its parent's coordinate system"

	| a3DVector anArray |

	anArray _ Array new: 3.
	a3DVector _ composite rotation.

	anArray at: 1 put: (a3DVector x).
	anArray at: 2 put: (a3DVector y).
	anArray at: 3 put: (a3DVector z).

	^ anArray.

	