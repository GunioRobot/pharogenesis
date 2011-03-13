obtainNewSearchString
	"Put up a box allowing the user to enter a fresh search string"

	| fragment |
	
	fragment := UIManager default request: 'type method name or fragment: ' initialAnswer: self currentQueryParameter.
	fragment ifNil: [^ self].
	(fragment := fragment copyWithout: $ ) size == 0  ifTrue: [^ self].
	currentQueryParameter := fragment.
	fragment := fragment asLowercase.
	currentQuery := #selectorName.
	self showQueryResultsCategory.
	self messageListIndex: 0