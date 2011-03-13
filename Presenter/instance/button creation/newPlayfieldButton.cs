newPlayfieldButton
	| aDict aButton aForm |
	aDict _ ScriptingSystem formDictionary.
	aButton _ ThreePhaseButtonMorph new.
	aButton image:  (aForm _ aDict at: 'NewPlayfield');
		offImage: aForm; pressedImage:  aForm.
	aButton actionSelector: #makeNewPlayfield; 
		arguments: Array new;
		actWhen: #buttonDown; target: self;
		setNameTo: 'Make Playfield';
		beRepelling;
		setProperty: #scriptingControl toValue: true;
		setBalloonText: 'Drag from here to create a new Playfield'.
	^ aButton