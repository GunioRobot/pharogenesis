browseAllMessages
	"Create and schedule a message set browser on all implementors of all
	the messages sent by the current method.  Created 1991 by tck;
	mofified 1/26/96 sw: put appropriate title on the window"

	| aClass aName |
	messageListIndex ~= 0 
		ifTrue: [Smalltalk browseAllImplementorsOfList:
				((aClass _ self selectedClassOrMetaClass) compiledMethodAt: (aName _ self selectedMessageName))
					messages asSortedCollection title:
		'All messages sent in ', aClass name, '.', aName]