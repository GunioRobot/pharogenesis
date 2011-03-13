pageOneToggleButtonsFor: anEToyHolder
	| aButton aDict |
	aDict _ ScriptingSystem formDictionary.

	^ #(
	('Sounds'	'SoundOn'		'SoundOff'  		toggleSoundsEnabled	soundsEnabled)
	('Fence'		'FenceOn'		'FenceOff'  		toggleFence			fenceEnabled)) with:
	#(
'Sounds:
If green, sounds will be 
heard when appropriate; if
red, sounds are suppressed'

'Fence:
If green, an invisible "fence"
keeps your objects inside of
the playfield')

	collect:
			[:q :helpString |
			aButton _ ToggleButtonMorph new setNameTo: q first.
			aButton onImage: (aDict at: q second);
				offImage: (aDict at: q third);
				pressedImage: nil;
				actionSelector: q fourth;
				stateSelector: q last;
				actWhen: #buttonDown; target: self;
				setInitialState;  "Obtains it from target"
				setBalloonText: helpString]