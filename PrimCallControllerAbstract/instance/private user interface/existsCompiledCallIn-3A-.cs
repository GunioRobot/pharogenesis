existsCompiledCallIn: aMethodRef 
	"This just means that there is a compiled in external prim call: from the 
	by compiler subclass point of view disabled prim calls not visible by 
	this method are also prim calls."
	^ aMethodRef compiledMethod primitive = 117