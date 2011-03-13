grabScreenAreaButton
  "not sent, momentarily.  A repository for this code"
	| button |
	button _ SimpleButtonMorph new.
	button target: associatedMorph primaryHand; 
		borderColor: Color black; 
		color: (Color r: 1.0 g: 0.8 b: 0.6) lighter;
		setNameTo: 'Grab Screen Area';
		label: 'Grab Screen Area';
		setProperty: #scriptingControl toValue: true;
		actionSelector: #grabDrawingFromScreen.
	^ button