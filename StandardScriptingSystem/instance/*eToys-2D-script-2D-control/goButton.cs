goButton
	| aButton |
	aButton :=  ThreePhaseButtonMorph new.
	aButton image:  (ScriptingSystem formAtKey: 'GoPicOn');
			offImage: (ScriptingSystem formAtKey: 'GoPic');
			pressedImage: (ScriptingSystem formAtKey: 'GoPicOn');
			actionSelector: #goUp:with:; 
			arguments: (Array with: nil with: aButton);
			actWhen: #buttonUp;
			target: self;
			setNameTo: 'Go Button';
			setBalloonText:
'Resume running all paused scripts' translated.
	^ aButton