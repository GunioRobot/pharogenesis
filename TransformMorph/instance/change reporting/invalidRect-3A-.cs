invalidRect: damageRect
	"Translate damage reports from submorphs by the scrollOffset."
	super invalidRect: (((transform localBoundsToGlobal: damageRect) intersect: bounds) expandBy: 1)