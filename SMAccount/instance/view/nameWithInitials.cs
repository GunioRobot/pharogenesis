nameWithInitials
	"Return name and developer initials within parentheses."

	^name, ' (', (initials isEmptyOrNil ifTrue: ['not entered'] ifFalse: [initials]) , ')'