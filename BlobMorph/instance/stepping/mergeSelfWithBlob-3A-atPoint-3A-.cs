mergeSelfWithBlob: aBlob atPoint: aPoint
	" It has already been determined that we merge with aBlob; we do all the work here. "
	| v v2 c |

	c := self bounds center.

	" Merge the vertices by throwing them all together in one pot "
	v := vertices, aBlob vertices.

	" Sort the vertices by degrees to keep them in order "
	v := (v asSortedCollection: [ :a :b | (a-c) degrees < (b-c) degrees ]) asArray.

	" Now, pick half of the vertices so the count stays the same "
	v2 := Array new: v size // 2.
	1 to: v2 size do: [ :n |
		v2 at: n put: (v at: n+n) ].
	v := v2.

	" Average each contiguous pair to help minimize jaggies "
	2 to: v size do: [ :n |
		v at: n put: ((v at: n) + (v at: n-1)) / 2.0 ].

	" Remember the new vertices, set a new velocity, then delete the merged blob "
	vertices := v.
	self setVelocity.
	aBlob delete
