setVersion
	"EToySystem setVersion"

	| newName |
	newName _ FillInTheBlank
		request: ('Please name this EToy system version.\The old version is:\',
					EToyVersion, '\set on ', EToyVersionDate) withCRs
 		initialAnswer: EToyVersion.
	newName size > 0 ifTrue:
		[EToyVersion _ newName.
		EToyVersionDate _ Date today printString]