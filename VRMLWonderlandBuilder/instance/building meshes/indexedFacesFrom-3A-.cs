indexedFacesFrom: anArray
	"Create and return a set of faces from the given index array"
	| faces index idx0 idx1 idx2 |
	faces _ WriteStream on: (B3DIndexedTriangleArray new: anArray size // 4).
	index _ 0.
	[index < anArray size] whileTrue:[
		idx0 _ anArray at: (index _ index + 1).
		idx1 _ anArray at: (index _ index + 1).
		[idx2 _ anArray at: (index _ index + 1).
		faces nextPut: (B3DIndexedTriangle with: idx0+1 with: idx1+1 with: idx2+1).
		idx1 _ idx2.
		index < anArray size
			ifTrue:[idx2 _ anArray at: (index_index+1)]
			ifFalse:[idx2 _ -1].
		idx2 = -1] whileFalse.
	].
	^faces contents