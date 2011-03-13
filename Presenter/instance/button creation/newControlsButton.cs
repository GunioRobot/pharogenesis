newControlsButton
	| aDict aButton aForm |
	aDict _ ScriptingSystem formDictionary.
	aButton _ ThreePhaseButtonMorph new.
	aButton image:  (aForm _ aDict at: 'Controls');
		offImage: aForm; pressedImage:  aForm.
	aButton actionSelector: #createControlPanel; 
		arguments: Array new;
		actWhen: #buttonDown; target: self;
		setNameTo: 'Make Controls';
		beRepelling;
		setProperty: #scriptingControl toValue: true;
		setBalloonText: 'Drag from here to get a Control panel'.
	^ aButton