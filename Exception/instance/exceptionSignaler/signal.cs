signal
	"Signal the occurrence of an exceptional condition."

	| result |
	initialContext == nil ifTrue: [initialContext := thisContext sender].
	resignalException := nil.
	(self setHandlerFrom: initialContext) == nil
		ifTrue: [^self defaultAction].
	result := self handlerAction.
	^resignalException == nil
		ifTrue: [result]
		ifFalse: [resignalException signal]