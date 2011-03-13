invalidRect: damageRect from: aMorph
	"Translate damage reports from submorphs by the scrollOffset."
	aMorph == self
		ifTrue:[super invalidRect: damageRect from: self]
		ifFalse:[super invalidRect: (((transform localBoundsToGlobal: damageRect) intersect: bounds) expandBy: 1) from: self].