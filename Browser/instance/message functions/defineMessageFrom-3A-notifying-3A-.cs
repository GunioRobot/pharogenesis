defineMessageFrom: aString notifying: aController
	"Compile the expressions in aString. Notify aController if a syntax error occurs. Install the compiled method in the selected class classified under  the currently selected message category name. Answer the selector obtained if compilation succeeds, nil otherwise."
	| selectedMessageName selector category oldMessageList |
	selectedMessageName _ self selectedMessageName.
	oldMessageList _ self messageList.
	contents _ nil.
	selector _ (Parser new parseSelector: aString).
	(self metaClassIndicated
		and: [(self selectedClassOrMetaClass includesSelector: selector) not
		and: [Metaclass isScarySelector: selector]])
		ifTrue: ["A frist-time definition overlaps the protocol of Metaclasses"
				(self confirm: ((selector , ' is used in the existing class system.
Overriding it could cause serious problems.
Is this really what you want to do?') asText makeBoldFrom: 1 to: selector size))
				ifFalse: [^nil]].
	selector _ self selectedClassOrMetaClass
				compile: aString
				classified: (category _ self selectedMessageCategoryName)
				notifying: aController.
	selector == nil ifTrue: [^ nil].
	contents _ aString copy.
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
	^ selector