testIsUnsentMessagesInClass
	| class otherClass expecetedMethReferences |
	class := classFactory newClass.
	class compile: 'messageNeverSentInTheSystemXXXXThisIsForTest ^self'.
	class compile: 'otherMessageNeverSentInTheSystemXXXXThisIsForTest ^self'.
	class compile: 'sentMessage'.
	otherClass := classFactory newClass.
	otherClass compile: 'printString self sentMessage'.
	expecetedMethReferences := (class selectors copyWithout: #sentMessage) collect: [:selector|
		MethodReference class: class selector: selector].
	self assert: (navigator unsentMessagesInClass: class) asSet = expecetedMethReferences