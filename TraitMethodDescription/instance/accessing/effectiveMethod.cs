effectiveMethod
	"Return the effective compiled method of this method description." 

	| locatedMethod method |
	method _ self providedMethod.
	method isNil ifFalse: [^ method].
	method _ self conflictMethod.
	method isNil ifFalse: [^ method].
	^ self requiredMethod.