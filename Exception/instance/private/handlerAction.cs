handlerAction

	| na handler returnValue |
	handler := handlerContext tempAt: 2.		"the second argument"
	na := handler numArgs.
	handlerContext tempAt: 3 put: false.
	returnValue := na == 0
		ifTrue: [handler value]
		ifFalse: [handler value: self].
	resignalException == nil ifFalse: [^returnValue].
	"Execution will only continue beyond this point if the handler did not specify a handler action."
	self return: returnValue