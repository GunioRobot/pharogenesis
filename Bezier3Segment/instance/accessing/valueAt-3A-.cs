valueAt: t
	| a b c d |

	"| p1 p2 p3 |
	p1 _ start interpolateTo: via1 at: t.
	p2 _ via1 interpolateTo: via2 at: t.
	p3 _ via2 interpolateTo: end at: t.
	p1 _ p1 interpolateTo: p2 at: t.
	p2 _ p2 interpolateTo: p3 at: t.
	^ p1 interpolateTo: p2 at: t"

	a _ (start negated) + (3 * via1) - (3 * via2) + (end).
	b _ (3 * start) - (6 * via1) + (3 * via2).
	c _ (3 * start negated) + (3 * via1).
	d _ start.
	^ ((a * t + b) * t + c) * t + d

