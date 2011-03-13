categories
	^ ServiceRegistry current categories select: [:e | e services includes: self]