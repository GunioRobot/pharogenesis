computeBoundingBox
  " copied from B3DIndexedMesh"
	| min max |
	min _ max _ nil.
	vertices do:[:vtx|
		min ifNil:[min _ vtx] ifNotNil:[min _ min min: vtx].
		max ifNil:[max _ vtx] ifNotNil:[max _ max max: vtx].
	].
	^Rectangle origin: min corner: max