toggleButtons
	| aButton aDict aList |
	aDict _ ScriptingSystem formDictionary.

	aList _ #(
	('Halos' 	'HalosOn'		'HalosOff' 		toggleShowHalos		mouseOverHalosEnabled)
	('Balloons'	'BalloonsOn'		'BalloonsOff' 	toggleShowBalloons	balloonHelpEnabled)
	('Sounds'	'SoundOn'		'SoundOff'  		toggleSoundsEnabled	soundsEnabled)
	('Fence'		'FenceOn'		'FenceOff'  		toggleFence			fenceEnabled)) with:

	#(
'Show Halos:
If green, then when the
cursor pauses over an object
on the playfield, the object
will sprout halos'

'Balloon Help:
If green, then when the
cursor pauses over an object
that has balloon help,
that help balloon is shown'

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
				setBalloonText: helpString;
				extent: (aDict at: q second) extent.
			aButton].

	^ aList