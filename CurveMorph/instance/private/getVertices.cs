getVertices
	| vtx |
	vtx _ WriteStream on: Array new.
	self lineSegmentsDo:[:pt1 :pt2| vtx nextPut: pt1].
	^vtx contents