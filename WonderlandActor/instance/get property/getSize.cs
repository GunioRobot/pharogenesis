getSize
	"Returns the scale factor of the actor"

	| anArray meshSize |

	meshSize _ self getBoundingBox extent.

	anArray _ Array new: 3.
	anArray at: 1 put: (meshSize x).
	anArray at: 2 put: (meshSize y).
	anArray at: 3 put: (meshSize z).

	^ anArray.
