setAuthorInitials
	"Put up a dialog allowing the user to specify the author's initials.  "

	self setAuthorInitials:
		(FillInTheBlank request: 'Please type your initals: '
					initialAnswer: AuthorInitials)