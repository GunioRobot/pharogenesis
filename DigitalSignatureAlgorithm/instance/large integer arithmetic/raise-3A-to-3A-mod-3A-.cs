raise: x to: y mod: n
	"Answer ((x raisedTo: y) \\ n) for integers x, y and n, but computed efficiently when x, y, and n are very large positive integers. From Schneier, p. 244."

	| s t u |
	s _ 1.
	t _ x.
	u _ y.
	[u = 0] whileFalse: [
		u odd ifTrue: [
			s _ s * t.
			s >= n ifTrue: [s _ s \\\ n]].
		t _ t * t.
		t >= n ifTrue: [t _ t \\\ n].
		u _ u bitShift: -1].
	^ s
