testIsMessageSentInPackageWithClassesActuallySendngTheMessage
	| classesSendingMessage |
	5 timesRepeat: [classFactory newClassInCategory: #One].
	5 timesRepeat: [classFactory newClassInCategory: #Two].
	classesSendingMessage := (classFactory createdClasses asArray first: 2), (classFactory createdClasses asArray last: 3).
	classesSendingMessage do: [:class|	
		class compile: 'meth self m'].
	self assert: (navigator isMessage: #m sentInPackageNamed: classFactory packageName).
	self assert: (navigator allSendersOf: #m inPackageNamed: classFactory packageName) size = 5