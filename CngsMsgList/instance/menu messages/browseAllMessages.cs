browseAllMessages
	"Create and schedule a message set browser on all implementors of all the messages sent by the current method.  Originally conceived and implemented by tck, 1991"

	| method filteredList aClass aName |	

	listIndex ~= 0 ifTrue:
		[method _ (aClass _ parent selectedClassOrMetaClass) compiledMethodAt:
						(aName _ parent selectedMessageName) ifAbsent: [^ self beep].
		filteredList _ method messages reject: 
			[:each | #(new initialize = ) includes: each].
		Smalltalk browseAllImplementorsOfList: filteredList asSortedCollection
			 title: 'All messages sent in ', aClass name, '.', aName]