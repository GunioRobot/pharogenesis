goToPage
	| pageNum |
	pageNum _ FillInTheBlank request: 'Page?' translated initialAnswer: '0'.
	pageNum isEmptyOrNil ifTrue: [^true].
	self goToPage: pageNum asNumber.
