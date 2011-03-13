find
	"Prompt the user for a string to search for, and search the receiver from the current selection onward for it.  1/26/96 sw"

	| reply |
	reply := UIManager default request: 'Find what? ' translated initialAnswer: ''.
	reply size == 0 ifTrue: [^ self].
	self setSearch: reply.
	ChangeText := FindText.  "Implies no replacement to againOnce: method"
	self againOrSame: true
	
