merge: aPolygon
	"Expand myself to enclose the other polygon.  (Later merge overlapping or disjoint in a smart way.)  For now, the two polygons must share at least two vertices.  Shared vertices must come one after the other in each polygon.  Polygons must not overlap."

	| shared mv vv hv xx |
	shared _ vertices select: [:mine | 
		(aPolygon vertices includes: mine)].
	shared size < 2 ifTrue: [^ nil].	"not sharing a segment"
	mv _ vertices asOrderedCollection.
	[shared includes: mv first] whileFalse: ["rotate them"
		vv _ mv removeFirst.
		mv addLast: vv].
	hv _ aPolygon vertices asOrderedCollection.
	[mv first = hv first] whileFalse: ["rotate him until same shared vertex is first"
		vv _ hv removeFirst.
		hv addLast: vv].
	[shared size > 2] whileTrue: [
		shared _ shared asOrderedCollection.
		(self mergeDropThird: mv in: hv from: shared) ifNil: [^ nil]].
		"works by side effect on the lists"
	(mv at: 2) = hv last ifTrue: [mv removeFirst; removeFirst.
		^ self setVertices: (hv, mv) asArray].
	(hv at: 2) = mv last ifTrue: [hv removeFirst; removeFirst.
		^ self setVertices: (mv, hv) asArray].
	(mv at: 2) = (hv at: 2) ifTrue: [hv removeFirst.  mv remove: (mv at: 2).
		xx _ mv removeFirst.
		^ self setVertices: (hv, (Array with: xx), mv reversed) asArray].
	mv last = hv last ifTrue: [mv removeLast.  hv removeFirst.
		^ self setVertices: (mv, hv reversed) asArray].
	^ nil
