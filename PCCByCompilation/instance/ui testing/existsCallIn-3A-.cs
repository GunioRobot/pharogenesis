existsCallIn: aMethodRef 
	"Here existsCompiledCallIn: (see also comment there) is sufficient to 
	query for enabled and failed, but not for disabled prim calls: so check 
	for disabled ones in sources, too."
	^ (self existsCompiledCallIn: aMethodRef)
		or: [self existsDisabledCallIn: aMethodRef]