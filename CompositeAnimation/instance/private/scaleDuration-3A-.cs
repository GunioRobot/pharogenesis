scaleDuration: scaleAmount
	"Scales the animation's duration by the specified amount"

	| i |

	super scaleDuration: scaleAmount.

	i _ 1.
	children do: [:child | child scaleDuration: (scaleAmount / (childLoopCounts at: i)).
						 i _ i + 1 ].
