newPaintingButton
	| aDict aButton |
	aDict _ ScriptingSystem formDictionary.
	aButton _ ThreePhaseButtonMorph new.
	aButton image:  (aDict at: 'PaintBrush');
		offImage: (aDict at: 'PaintBrush'); pressedImage:  (aDict at: 'PaintBrush').
	aButton actionSelector: #dragAndDropToMakeNewDrawing; 
		arguments: Array new;
		actWhen: #buttonDown; target: self;
		setNameTo: 'New Painting';
		beRepelling;
		setProperty: #scriptingControl toValue: true;
		setBalloonText: 'Drag a paintbrush into any playfield
to start drawing a new player there.'.
	^ aButton