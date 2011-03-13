browseAllMessages
	"Create and schedule a message set browser on all implementors of all the messages sent by the current method."

	| aClass aName method filteredList |
	(aName _ self selectedMessageName) ifNotNil: [
		method _ (aClass _ self selectedClassOrMetaClass) compiledMethodAt: aName.
		filteredList _ method messages reject: 
			[:each | #(new initialize = ) includes: each].
		Smalltalk browseAllImplementorsOfList: filteredList asSortedCollection
			 title: 'All messages sent in ', aClass name, '.', aName]
