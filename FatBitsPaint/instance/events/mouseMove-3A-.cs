mouseMove: evt

	| p p2 damageRect |
	p _ self griddedPoint: evt.
	lastMouse = p ifTrue: [^ self].
	lastMouse ifNil: [lastMouse _ p].  "first point in a stroke"
	"draw etch-a-sketch style-first horizontal, then vertical"
	p2 _ p x@lastMouse y.
	brush drawFrom: lastMouse to: p2.
	brush drawFrom: p2 to: p.
			
	damageRect _ 
		((lastMouse min: p) - brush sourceForm extent) corner:
		((lastMouse max: p) + brush sourceForm extent).
	self invalidRect: (damageRect translateBy: self position).
	lastMouse _ p.
