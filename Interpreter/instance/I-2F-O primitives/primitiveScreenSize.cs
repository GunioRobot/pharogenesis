primitiveScreenSize
	"Return a point indicating the current size of the Smalltalk window."

	| pointWord |
	self pop: 1.
	pointWord _ self ioScreenSize.
	self push:
		(self makePointwithxValue: ((pointWord >>16) bitAnd: 16rFFFF)
						   yValue: (pointWord bitAnd: 16rFFFF)).