previousPageButton
	"Answer a button that will take the user to the previous page of its enclosing book"

	| aButton |
	aButton _ SimpleButtonMorph new.
	aButton target: aButton; actionSelector: #previousOwnerPage; color: Color yellow; label: '<-'.
	aButton setNameTo: 'previous'.
	^ aButton