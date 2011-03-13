closeTypeIn
	"Lock the model if something actually was typed."

	beginTypeInBlock ~~ nil ifTrue: [self lockModel].
	super closeTypeIn