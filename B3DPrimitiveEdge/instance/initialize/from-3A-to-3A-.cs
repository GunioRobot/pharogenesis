from: vtx0 to: vtx1
	(vtx0 sortsBefore: vtx1) 
		ifTrue:[v0 _ vtx0. v1 _ vtx1]
		ifFalse:[v1 _ vtx0. v0 _ vtx1].