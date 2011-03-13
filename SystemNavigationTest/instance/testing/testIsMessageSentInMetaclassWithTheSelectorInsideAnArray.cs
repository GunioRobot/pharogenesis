testIsMessageSentInMetaclassWithTheSelectorInsideAnArray
	|class|
	class := classFactory newClass.
	class class compile: 'meth ^#(a b m c)'.
	self assert: (navigator isMessage: #m sentInClass: class).
	self assert: (navigator allSendersOf: #m inClass: class) size = 1