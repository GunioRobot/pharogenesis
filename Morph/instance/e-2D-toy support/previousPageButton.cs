previousPageButton
	| aButton |
	aButton _ SimpleButtonMorph new.
	aButton target: aButton; actionSelector: #previousOwnerPage; color: Color yellow; label: '<-'.
	aButton setNameTo: 'previous'.
	^ aButton