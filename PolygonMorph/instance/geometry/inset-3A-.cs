inset: amt
	"Only works if I am made of rectangles (every segment of me is horizontal or vertical).  Inset each vertex by amt.  Uses containsPoint."

	| delta four cnt offset |
	delta _ amt asPoint.
	four _ {delta.  -1@1 * delta.  -1@-1 * delta.  1@-1 * delta}.
	self setVertices: (vertices collect: [:vv | 
		cnt _ 0.
		offset _ four detectSum: [:del | 
			(self containsPoint: del+vv) ifTrue: [cnt _ cnt + 1. del] ifFalse: [0@0]].
		cnt = 2 ifTrue: [offset _ offset // 2].
		vv + offset]).