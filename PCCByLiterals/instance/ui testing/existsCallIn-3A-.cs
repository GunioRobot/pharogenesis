existsCallIn: aMethodRef 
	"Here >>existsCompiledCallIn: (see also comment there) is sufficient to 
	query for all enabled, failed and disabled prim calls; for the by 
	compiler version it is not sufficient for disabled ones."
	^ self existsCompiledCallIn: aMethodRef