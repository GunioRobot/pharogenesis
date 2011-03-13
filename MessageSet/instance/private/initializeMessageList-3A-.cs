initializeMessageList: anArray
	"Initialize the message list from anArray, which must contain objects which, when sent #asString, answer a string in standard format such as 'Rectangle width'"

	messageList _ anArray collect: [:each |
		MessageSet parse: each asString toClassAndSelector: [:class :sel |
			class ifNotNil: [class name , ' ' , sel , ' {' , ((class organization categoryOfElement: sel) ifNil: ['']) , '}']]]
		thenSelect:
			[:each | each notNil].
	messageListIndex _ 0.
	contents _ ''