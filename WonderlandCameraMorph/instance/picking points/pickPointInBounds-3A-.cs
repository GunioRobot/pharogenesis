pickPointInBounds: boundary
	"Chooses a random point so that this morph lies within the specified bounds"

	| xpos ypos |

	xpos _ (boundary left) + (0 to: ((boundary width) - (bounds width))) atRandom.
	ypos _ (boundary top) + (0 to: ((boundary height) - (bounds height))) atRandom.

	^ xpos@ypos.

