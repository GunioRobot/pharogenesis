fullDamageRect: maxBounds
	invalidRects isEmpty ifTrue:[^0@0 corner: 0@0].
	^fullDamageRect intersect: maxBounds