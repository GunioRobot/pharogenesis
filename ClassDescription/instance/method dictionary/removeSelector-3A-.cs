removeSelector: selector 
	| priorMethod | 
	"Remove the message whose selector is given from the method 
	dictionary of the receiver, if it is there. Answer nil otherwise."

	(self methodDict includesKey: selector) ifFalse: [^ nil].
	priorMethod _ self compiledMethodAt: selector.
	Smalltalk changes removeSelector: selector class: self
		priorMethod: priorMethod
		lastMethodInfo: {priorMethod sourcePointer.
						(self whichCategoryIncludesSelector: selector)}.
	super removeSelector: selector.
	self organization removeElement: selector.
	self acceptsLoggingOfCompilation ifTrue:
		[Smalltalk logChange: self name , ' removeSelector: #' , selector]