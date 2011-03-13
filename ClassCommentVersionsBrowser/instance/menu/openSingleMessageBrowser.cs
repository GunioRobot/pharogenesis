openSingleMessageBrowser
	| mr |
	"Create and schedule a message list browser populated only by the currently selected message"

	mr := MethodReference new
				setStandardClass: self selectedClass
				methodSymbol: #Comment.

	self systemNavigation 
		browseMessageList: (Array with: mr)
		name: mr asStringOrText
		autoSelect: nil