obtainNewSearchString
	"Put up a box allowing the user to enter a fresh search string"

	| fragment |
	
	fragment _ FillInTheBlank request: 'type method name or fragment: ' initialAnswer: self currentQueryParameter.
	fragment ifNil: [^ self].
	(fragment _ fragment copyWithout: $ ) size == 0  ifTrue: [^ self].
	currentQueryParameter _ fragment.
	fragment _ fragment asLowercase.
	currentQuery _ #selectorName.
	self showQueryResultsCategory.
	self messageListIndex: 0