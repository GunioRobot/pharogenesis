contents: input notifying: aController 
	"The retrieved information has changed and its source must now be 
	updated. The information can be a variety of things, depending on the 
	list selections (such as templates for class or message definition, methods) 
	or the user menu commands (such as definition, comment, hierarchy). 
	Answer the result of updating the source."

	| aString aText theClass |
	aString _ input asString.
	aText _ input asText.

	editSelection == #editComment 
		ifTrue: [theClass _ self selectedClass.
				theClass ifNil: [PopUpMenu notify: 'You must select a class
before giving it a comment.'.
				^ false].
				theClass comment: aText. ^ true].
	editSelection == #editMessageCategories 
		ifTrue: [^ self changeMessageCategories: aString].

	self inform:'You cannot change the current selection'.
	^false
