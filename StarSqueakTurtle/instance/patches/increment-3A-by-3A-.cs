increment: patchVar by: delta
	"Increment the value of the given patch variable below this turtle by the given amount (positive or negative)."

	 world incrementPatchVariable: patchVar atX: x y: y by: delta.
