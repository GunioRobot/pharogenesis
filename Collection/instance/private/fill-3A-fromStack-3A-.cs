fill: numElements fromStack: aContext 
	"Fill me with numElements elements, popped in reverse order from
	 the stack of aContext.  Do not call directly: this is called indirectly by {1. 2. 3}
	 constructs.  Subclasses that support at:put: instead of add: should override
	 this and call Context<pop:toIndexable:"

	aContext pop: numElements toAddable: self