mouseMove: evt

	| state lastP p pen |
	state _ drawState at: evt hand ifAbsent: [^ self].
	lastP _ state at: LastMouseIndex.
	p _ evt cursorPoint.
	p = lastP ifTrue: [^ self].

	pen _ state at: PenIndex.
	pen drawFrom: lastP - bounds origin to: p - bounds origin.
	self invalidRect: (
		((lastP min: p) - pen sourceForm extent) corner:
		((lastP max: p) + pen sourceForm extent)).
	state at: LastMouseIndex put: p.
