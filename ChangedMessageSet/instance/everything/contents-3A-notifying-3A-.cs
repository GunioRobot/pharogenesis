contents: aString notifying: aController
	| selectedMessageName selector oldMessageList |
	selectedMessageName _ self selectedMessageName.
	oldMessageList _ self messageList.
	contents _ nil.
	selector _ 
		self selectedClassOrMetaClass
				compile: aString
				classified:  self selectedMessageCategoryName
				notifying: aController.
	selector == nil ifTrue: [^ false].
	contents _ aString copy.
	selector ~~ selectedMessageName
		ifTrue: 
			[(oldMessageList includes: selector)
				ifFalse: [self initializeMessageList: changeSet changedMessageListAugmented.
						self changed: #messageListChanged].
			self messageListIndex: (self messageList indexOf: selector)].
	^ true