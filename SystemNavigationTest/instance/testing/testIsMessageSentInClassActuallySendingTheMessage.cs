testIsMessageSentInClassActuallySendingTheMessage
	|class|
	class := classFactory newClass.
	class compile: 'meth self m'.
	self assert: (navigator isMessage: #m sentInClass: class).
	self assert: (navigator allSendersOf: #m inClass: class) size = 1