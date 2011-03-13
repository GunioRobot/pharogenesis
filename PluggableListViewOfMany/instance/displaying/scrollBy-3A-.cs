scrollBy: anInteger
	"This is a possible way to intercept what ListOfManyController did to get multiple selections to show.  Feel to replace this."

	| ans |
	ans := super scrollBy: anInteger.
"	self displaySelectionBox."
	^ ans