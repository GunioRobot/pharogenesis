invalidRect: damageRect
	"Translate damage reports from submorphs by the scrollOffset."
	owner ifNil: [^ self].
	^ owner invalidRect: ((transform invertRect: damageRect) intersect: bounds)