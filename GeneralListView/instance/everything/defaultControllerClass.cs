defaultControllerClass 
	"Refer to the comment in View|defaultControllerClass."

	controllerClass == nil ifTrue: [self error: 'No one told me about my controller'].
	^controllerClass