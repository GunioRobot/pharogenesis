testIsMessageSentInSystemWithClassesActuallySendngTheMessage
	| classesSendingMessage sentMessageSelector|
	sentMessageSelector := 'MessageSentOnlyByTestClassesXXXShouldNotBeRealyDefined' asSymbol.
	5 timesRepeat: [classFactory newClassInCategory: #One].
	5 timesRepeat: [classFactory newClassInCategory: #Two].
	classesSendingMessage := (classFactory createdClasses asArray first: 2), (classFactory createdClasses asArray last: 3).
	classesSendingMessage do: [:class|	
		class compile: 'meth self ', sentMessageSelector].
	self assert: (navigator allSendersOf: sentMessageSelector) size = 5