browseUnusedMethods
	| classes unsent messageList |
	classes _ Array with: self selectedClass with: self selectedClass class.
	unsent _ Set new.
	classes do: [:c | unsent addAll: c selectors].
	unsent _ Smalltalk allUnSentMessagesIn: unsent.
	messageList _ OrderedCollection new.
	classes do: [:c | (c selectors select: [:s | unsent includes: s]) asSortedCollection
					do: [:sel | messageList add: c name , ' ' , sel]].
	Smalltalk browseMessageList: messageList name: 'Unsent Methods in ', self selectedClass name