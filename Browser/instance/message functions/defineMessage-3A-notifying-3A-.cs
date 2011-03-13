defineMessage: aString notifying: aController 
	"Compile the expressions in aString. Notify aController if a syntax error 
	occurs. Install the compiled method in the selected class classified under 
	the currently selected message category name. Answer true if 
	compilation succeeds, false otherwise."
	| selectedMessageName selector category oldMessageList |
	selectedMessageName := self selectedMessageName.
	oldMessageList := self messageList.
	contents := nil.
	selector := self selectedClassOrMetaClass
				compile: aString
				classified: (category := self selectedMessageCategoryName)
				notifying: aController.
	selector == nil ifTrue: [^ false].
	contents := aString copy.
	selector ~~ selectedMessageName
		ifTrue: 
			[category = ClassOrganizer nullCategory
				ifTrue: [self changed: #classSelectionChanged.
						self changed: #classList.
						self messageCategoryListIndex: 1].
			self setClassOrganizer.  "In case organization not cached"
			(oldMessageList includes: selector)
				ifFalse: [self changed: #messageList].
			self messageListIndex: (self messageList indexOf: selector)].
	^ true