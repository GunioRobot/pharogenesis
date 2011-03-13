closeTypeIn
	"Note edit if something actually was typed."

	beginTypeInBlock ~~ nil ifTrue: [self userHasEdited].
	super closeTypeIn.
