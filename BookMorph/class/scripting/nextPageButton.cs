nextPageButton
	"Answer a button that will take the user to the next page of its enclosing book"

	| aButton |
	aButton _ SimpleButtonMorph new.
	aButton target: aButton; actionSelector: #nextOwnerPage; label: '->'; color: Color yellow.
	aButton setNameTo: 'next'.
	^ aButton