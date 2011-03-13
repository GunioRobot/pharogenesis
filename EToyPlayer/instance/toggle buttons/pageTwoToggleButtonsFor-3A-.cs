pageTwoToggleButtonsFor: anEToyHolder
	| aButton aDict |
	aDict _ ScriptingSystem formDictionary.

	^ #(
	('Halos' 	'HalosOn'		'HalosOff' 		toggleShowHalos		mouseOverHalosEnabled)
	('Balloons'	'BalloonsOn'		'BalloonsOff' 	toggleShowBalloons	balloonHelpEnabled)
	('ColorTiles'	'ColorTilesOn'	'ColorTilesOff'	toggleColoredTiles	coloredTilesEnabled)) with:
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

'Colored Tiles:
If green, then colored tiles are shown
If pink, then all tiles are plain')

	collect:
			[:q :helpString |
			aButton _ ToggleButtonMorph new setNameTo: q first.
			aButton onImage: (aDict at: q second);
				offImage: (aDict at: q third);
				pressedImage: nil;
				actionSelector: q fourth;
				stateSelector: q last;
				actWhen: #buttonDown; target: self;
				extent: (aDict at: q second) extent;
				setInitialState;  "Obtains it from target"
				setBalloonText: helpString]