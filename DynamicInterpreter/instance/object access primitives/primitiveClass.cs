primitiveClass
	| instance class cp |
	instance _ self popStack.
	class _ self fetchClassOf: instance.
	class = (self splObj: ClassPseudoContext) ifTrue: [
		cp _ self pseudoCachedContextAt: instance.
		(self isCachedMethodContext: cp)
			ifTrue: [class _ self splObj: ClassMethodContext]
			ifFalse: [class _ self splObj: ClassBlockContext]].
	self push: class