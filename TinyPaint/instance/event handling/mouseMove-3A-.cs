mouseMove: evt

	| p |
	p _ evt cursorPoint.
	p = lastMouse ifTrue: [^ self].
	brush drawFrom: lastMouse - bounds origin to: p - bounds origin.
	self invalidRect: (
		((lastMouse min: p) - brush sourceForm extent) corner:
		((lastMouse max: p) + brush sourceForm extent)).
	lastMouse _ p.
