previousPageButton
	| aButton |
	aButton _ SimpleButtonMorph new.
	aButton target: aButton; actionSelector: #previousOwnerPage; label: '<-'.
	aButton setNameTo: 'previous'.
	^ aButton