invalidRect: damageRect
	owner ifNotNil:
		[owner invalidRect: (damageRect merge: (damageRect translateBy: shadowOffset))].