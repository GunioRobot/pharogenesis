find
	"Prompt the user for a string to search for, and search the receiver from the current selection onward for it.  1/26/96 sw"

	| reply |
	reply _ FillInTheBlank request: 'Find what? ' initialAnswer: ''.
	reply size == 0 ifTrue: [^ self].
	self setSearch: reply.
	ChangeText _ FindText.  "Implies no replacement to againOnce: method"
	self againOrSame: true
	
