allSubclasses
	"Answer a Set of the receiver's and the receiver's descendent's subclasses. "

	| scan scanTop |
	scan _ OrderedCollection withAll: self subclasses.
	scanTop _ 1.
	[scanTop > scan size]
		whileFalse: [scan addAll: (scan at: scanTop) subclasses.
			scanTop _ scanTop + 1].
	^ scan asSet