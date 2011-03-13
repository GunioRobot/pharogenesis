goButton
	| aDict |
	goButton == nil  ifTrue:
		[aDict _ ScriptingSystem formDictionary.
		goButton _ ThreePhaseButtonMorph new.
		goButton image:  (aDict at: 'GoPicOn');
			offImage: (aDict at: 'GoPic');
			pressedImage: (aDict at: 'GoPicOn');
			actionSelector: #goUp:with:; 
			arguments: (Array with: nil with: goButton);
			actWhen: #buttonUp; target: self;
			setNameTo: 'Go Button';
			setProperty: #scriptingControl toValue: true;
			setBalloonText:
'Press Go to resume running
all paused scripts'].

	goButton isInWorld ifFalse:
		[associatedMorph addMorph: (goButton beRepelling position: (self stepButton topRight + (1@0)))].

	^ goButton
