setAuthorInitials
	"Put up a dialog allowing the user to specify the author's initials.  5/10/96 sw"

	| initials reply |
	initials _ Utilities authorInitials.
	reply _ FillInTheBlank request: 'New author initals: ' initialAnswer: initials.
	(reply size > 0 and: [reply ~~ initials]) ifTrue:
		[Utilities authorInitials: reply.
		Transcript cr; show: 'author initials are now ', reply]