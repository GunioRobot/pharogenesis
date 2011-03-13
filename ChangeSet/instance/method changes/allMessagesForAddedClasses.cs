allMessagesForAddedClasses
	| messageList  mAssoc |
	"Smalltalk changes allMessagesForAddedClasses"
	messageList _ SortedCollection new.
	classChanges associationsDo:
		[:clAssoc |
		(clAssoc value includes: #add)
			ifTrue:
				[(Smalltalk at: clAssoc key) selectorsDo:
					[:aSelector | 
						messageList add: clAssoc key asString, ' ' , aSelector].
				(Smalltalk at: clAssoc key) class selectorsDo:
					[:aSelector | 
						messageList add: clAssoc key asString, ' class ' , aSelector]]].
	^ messageList asArray