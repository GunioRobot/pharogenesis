mergeDropThird: mv in: hv from: shared
	"We are merging two polygons.  In this case, they have at least three identical shared vertices.  Make sure they are sequential in each, and drop the middle one from vertex lists mv, hv, and shared.  First vertices on lists are identical already."

	"know (mv first = hv first)"
	| mdrop vv |
	(shared includes: (mv at: mv size - 2)) 
		ifTrue: [(shared includes: (mv last)) ifTrue: [mdrop _ mv last]]
		ifFalse: [(shared includes: (mv last)) ifTrue: [
			(shared includes: (mv at: 2)) ifTrue: [mdrop _ mv first]]].
	(shared includes: (mv at: 3)) ifTrue: [
		(shared includes: (mv at: 2)) ifTrue: [mdrop _ mv at: 2]].
	mdrop ifNil: [^ nil].
	mv remove: mdrop.
	hv remove: mdrop.
	shared remove: mdrop.
	[shared includes: mv first] whileFalse: ["rotate them"
		vv _ mv removeFirst.
		mv addLast: vv].
	[mv first = hv first] whileFalse: ["rotate him until same shared vertex is first"
		vv _ hv removeFirst.
		hv addLast: vv].
