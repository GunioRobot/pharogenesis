contents: aString notifying: aController
	| selectedMessageName selector oldMessageList cls |
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
	selector ~~ selectedMessageName ifTrue: 
			[(oldMessageList includes: selector) ifFalse: [
					self initializeMessageList: changeSet changedMessageListAugmented.
					self changed: #messageList].
			self messageListIndex: (self messageList indexOf: (cls name, ' ', selector))].
	^ true