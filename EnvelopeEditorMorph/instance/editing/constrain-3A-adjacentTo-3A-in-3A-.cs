constrain: xVal adjacentTo: ix in: points
	"Return xVal, restricted between points adjacent to vertX"
	| newVal |
	newVal _ xVal.
	ix > 1 ifTrue: [newVal _ newVal max: (points at: ix-1) x].
	ix < points size ifTrue: [newVal _ newVal min: (points at: ix+1) x].
	^ newVal