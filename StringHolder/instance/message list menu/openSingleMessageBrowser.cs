openSingleMessageBrowser
	| msgName title |
	"Create and schedule a message list browser populated only by the currently selected message"

	(msgName _ self selectedMessageName) ifNil: [^ self].
	Smalltalk browseMessageList: (Array with: (title _ self selectedClassOrMetaClass name, ' ', msgName))
		name: title autoSelect: nil