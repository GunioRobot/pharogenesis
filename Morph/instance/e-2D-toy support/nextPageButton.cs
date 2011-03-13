nextPageButton
	| aButton |
	aButton _ SimpleButtonMorph new.
	aButton target: aButton; actionSelector: #nextOwnerPage; label: '->'; color: Color yellow.
	aButton setNameTo: 'next'.
	^ aButton