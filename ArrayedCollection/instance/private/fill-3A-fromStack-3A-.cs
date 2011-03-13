fill: numElements fromStack: aContext 
	"Fill me with numElements elements, popped in reverse order from
	 the stack of aContext.  Do not call directly: this is called indirectly by {1. 2. 3}
	 constructs."

	aContext pop: numElements toIndexable: self