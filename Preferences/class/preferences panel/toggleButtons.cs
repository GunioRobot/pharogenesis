toggleButtons
	| aButton  aList |

	self flag: #deferred.  "moved to Preferences but not presently used and not readily usable in this format without some work"

	aList _ #(
	('Balloons'	'BalloonsOn'		'BalloonsOff' 	toggleShowBalloons	balloonHelpEnabled)
	('Sounds'	'SoundOn'		'SoundOff'  		toggleSoundsEnabled	soundsEnabled)
	('Fence'		'FenceOn'		'FenceOff'  		toggleFence			fenceEnabled)) with:

	#(
'Balloon Help: If green, then when the cursor pauses over an object that has balloon help, that help balloon is shown'

'Sounds: If green, sounds will be  heard when appropriate; if red, sounds are suppressed.'

'Fence: If green, an invisible "fence" keeps your objects from straying outside their containers when their scripts move them.')

	collect:
			[:q :helpString |
			aButton _ ToggleButtonMorph new setNameTo: q first.
			aButton onImage: (ScriptingSystem formAtKey: q second);
				offImage: (ScriptingSystem formAtKey: q third);
				pressedImage: nil;
				actionSelector: q fourth;
				stateSelector: q last;
				actWhen: #buttonDown;
				target: self;
				setInitialState;  "Obtains it from target"
				setBalloonText: helpString;
				extent: (ScriptingSystem formAtKey: q second) extent.
			aButton].

	^ aList