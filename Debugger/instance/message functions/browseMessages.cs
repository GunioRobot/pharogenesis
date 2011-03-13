browseMessages
	"Show a menu of all messages sent by the currently selected message.
	Create and schedule a message set browser of all implementors of the 
	message chosen. Do nothing if no message is chosen."

	contextStackIndex = 0 ifTrue: [^self].
	Smalltalk showMenuThenBrowse:
		(self selectedClassOrMetaClass compiledMethodAt: self selectedMessageName)
			messages asSortedCollection