defineMessage: aString notifying: aController 
	"Compile the expressions in aString. Notify aController if a syntax error 
	occurs. Install the compiled method in the selected class classified under 
	the currently selected message category name. Answer true if 
	compilation succeeds, false otherwise."

	| selectedMessageName selector category oldMessageList notice |
	selectedMessageName _ self selectedMessageName.
	oldMessageList _ self messageList.
	contents _ nil.
	selector _ 
		self selectedClassOrMetaClass
				compile: aString
				classified: (category _ self selectedMessageCategoryName)
				notifying: aController.
	notice _ self selectedClassOrMetaClass checkForPerform: selector in: aController.
	selector == nil ifTrue: [^false].
	contents _ aString copy.
	selector ~~ selectedMessageName
		ifTrue: 
			[category = ClassOrganizer nullCategory
				ifTrue: [self changed: #classSelectionChanged.
						self messageCategoryListIndex: 1].
			self setClassOrganizer.  "In case organization not cached"
			(oldMessageList includes: selector)
				ifFalse: [self changed: #messageListChanged].
			self messageListIndex: (self messageList indexOf: selector)].
	notice size = 0 ifFalse: ["insert the notice"
			aController notify: notice
				at: contents size + 1
				in: nil.
			self lock  "code is dirty"].
	^true