defaultAction
	"The default action taken if the exception is signaled."


	^self readOnly
		ifTrue: [StandardFileStream readOnlyFileDoesNotExistUserHandling: self fileName]
		ifFalse: [StandardFileStream fileDoesNotExistUserHandling: self fileName]
