looped
	"This method creates a copy of an animation and loops it forever."

	| anim |

	anim _ self copy.
	anim setLoopCount: Infinity.

	^ anim.
