browseSendersOfMessages
	"Show a menu of all messages sent by the currently selected message. 
	Create and schedule a message set browser of all senders of the 
	message chosen. Do nothing if no message is chosen.  Derived from
    browseMessages, 1/8/96 sw"

	contextStackIndex = 0 ifTrue: [^self].
	Smalltalk showMenuThenBrowseSendersOf:
		(self selectedClassOrMetaClass compiledMethodAt: self selectedMessageName)
			messages asSortedCollection