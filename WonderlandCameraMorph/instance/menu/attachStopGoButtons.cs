attachStopGoButtons
	| goButton stopButton wrapper |
	goButton _  ThreePhaseButtonMorph new.
	goButton image:  (ScriptingSystem formAtKey: 'GoPicOn');
			offImage: (ScriptingSystem formAtKey: 'GoPic');
			pressedImage: (ScriptingSystem formAtKey: 'GoPicOn');
			actionSelector: #setProperty:toValue:; 
			arguments: (Array with: #keepStepping with: true);
			actWhen: #buttonUp;
			target: self;
			setNameTo: 'Go Button'.
	stopButton _ ThreePhaseButtonMorph new.
	stopButton
		image:  (ScriptingSystem formAtKey: 'StopPic');
		offImage: (ScriptingSystem formAtKey: 'StopPic');
		pressedImage:  (ScriptingSystem formAtKey: 'StopPicOn');
		actionSelector: #removeProperty:; 
		arguments: (Array with: #keepStepping);
		actWhen: #buttonUp;
		target: self;
		setNameTo: 'Stop Button'. 
	wrapper _ AlignmentMorph newRow setNameTo: 'wonderland controls'.
	wrapper vResizing: #shrinkWrap.
	wrapper hResizing: #shrinkWrap.
	wrapper beTransparent.
	wrapper addMorphBack: goButton; addMorphBack: stopButton.
	self world primaryHand attachMorph: wrapper.