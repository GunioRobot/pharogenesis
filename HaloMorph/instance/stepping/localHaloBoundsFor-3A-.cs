localHaloBoundsFor: aMorph

	"aMorph may be in the hand and perhaps not in our world"

	| r |

	r _ aMorph worldBoundsForHalo truncated.
	aMorph world = self world ifTrue: [^r].
	^((self transformFromOutermostWorld) globalBoundsToLocal: r) truncated