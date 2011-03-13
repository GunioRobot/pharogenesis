newPartsBinButton
	| aDict aButton aForm |
	aDict _ ScriptingSystem formDictionary.
	aButton _ ThreePhaseButtonMorph new.
	aButton image:  (aForm _ aDict at: 'PartsBin');
		offImage: aForm; pressedImage:  aForm.
	aButton actionSelector: #createStandardPartsBin; 
		arguments: Array new;
		actWhen: #buttonDown; target: self;
		setNameTo: 'Make Parts Bin';
		beRepelling;
		setProperty: #scriptingControl toValue: true;
		setBalloonText: 'Drag from here to create a new Parts Bin'.
	^ aButton