showMethodsWithInitials
	"Prompt the user for initials to scan for; then show, in the query-results category, all methods with those initials in their time stamps"

	| initials |
	initials _ FillInTheBlank request: 'whose initials? ' initialAnswer: Utilities authorInitials.
	initials isEmptyOrNil ifTrue: [^ self].
	self showMethodsWithInitials: initials


