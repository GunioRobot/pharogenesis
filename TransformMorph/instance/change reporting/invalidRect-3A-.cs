invalidRect: damageRect
	"Translate damage reports from submorphs by the scrollOffset."
	| affectedRect |
	owner ifNil: [^ self].
	transform isPureTranslation ifTrue:
		[^ owner invalidRect: (transform invertRect: damageRect)].
	affectedRect _ (transform invert: damageRect topLeft) extent: 0@0.
	affectedRect _ affectedRect encompass: (transform invert: damageRect topRight).
	affectedRect _ affectedRect encompass: (transform invert: damageRect bottomLeft).
	affectedRect _ affectedRect encompass: (transform invert: damageRect bottomRight).
	owner invalidRect: (affectedRect expandBy: 1)
