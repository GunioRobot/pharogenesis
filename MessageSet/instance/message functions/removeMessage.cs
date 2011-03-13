removeMessage
	"Remove the selected message from the system. 1/15/96 sw"

	| messageName confirmation |

	messageListIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	messageName _ self selectedMessageName.
	confirmation _ self selectedClassOrMetaClass confirmRemovalOf: messageName.
	confirmation == 3 ifTrue: [^ self].

	self selectedClassOrMetaClass removeSelector: messageName.
	self deleteFromMessageList: self selection.
	self reformulateList.

	confirmation == 2 ifTrue:
		[Smalltalk browseAllCallsOn: messageName]