contents: aString notifying: aController
	"Accept the string as new source for the current method, and make certain the annotation pane gets invalidated"

	| selectedMessageName selector oldMessageList cls |
	self okayToAccept ifFalse: [^ false].
	selectedMessageName _ self selectedMessageName.
	oldMessageList _ self messageList.
	contents _ nil.
	selector _ self selectedClassOrMetaClass
				compile: aString
				classified:  self selectedMessageCategoryName
				notifying: aController.
	selector == nil ifTrue: [^ false].
	cls _ self selectedClassOrMetaClass.
	contents _ aString copy.
	self changed: #annotation.
	selector ~~ selectedMessageName ifTrue: 
			[(oldMessageList includes: selector) ifFalse:
					[self initializeMessageList: changeSet changedMessageListAugmented.
					self changed: #messageList].
			self messageListIndex: (self messageList indexOf: (cls name, ' ', selector))].
	^ true