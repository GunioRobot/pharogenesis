invalidRect: damageRect
	super invalidRect: (damageRect merge: (damageRect translateBy: self shadowOffset)).