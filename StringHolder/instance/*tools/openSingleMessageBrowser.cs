openSingleMessageBrowser
	| msgName mr |
	"Create and schedule a message list browser populated only by the currently selected message"

	(msgName := self selectedMessageName) ifNil: [^ self].

	mr := MethodReference new
		setStandardClass: self selectedClassOrMetaClass
		methodSymbol: msgName.

	self systemNavigation 
		browseMessageList: (Array with: mr)
		name: mr asStringOrText
		autoSelect: nil