prologue: currentTime
	"comment stating purpose of message"

	| index |

	super prologue: currentTime.

	index _ 1.
	children do: [:child | child setLoopCount: (childLoopCounts at: index).
						 index _ index + 1. ].
