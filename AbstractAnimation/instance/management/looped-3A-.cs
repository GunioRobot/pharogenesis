looped: numberOfTimes
	"This method creates a copy of an animation and loops it for the specified number of times."

	| anim |

	anim _ self copy.
	anim setLoopCount: numberOfTimes.

	^ anim.
