testIsUnsentMessagesInCategory
	| class otherClass expecetedMethReferencesInClass expecetedMethReferencesInOtherClass |
	class := classFactory newClass.
	class compile: 'messageNeverSentInTheSystemXXXXThisIsForTest ^self'.
	class compile: 'sentMessage'.
	otherClass := classFactory newClass.
	otherClass compile: 'printString self sentMessage'.
	otherClass compile: 'otherMessageNeverSentInTheSystemXXXXThisIsForTest ^self'.
	expecetedMethReferencesInClass := (class selectors copyWithout: #sentMessage) collect: [:selector|
		MethodReference class: class selector: selector].
	expecetedMethReferencesInOtherClass := (otherClass selectors copyWithout: #printString) collect: [:selector|
		MethodReference class: otherClass selector: selector].
	self assert: (navigator unsentMessagesInCategory: classFactory defaultCategory) asSet = (expecetedMethReferencesInClass, expecetedMethReferencesInOtherClass)