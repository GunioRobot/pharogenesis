initializeIn: aWorld

	| aDict position aButton indent aFont |
	aDict _ ScriptingSystem formDictionary.
	aFont _ ScriptingSystem fontForScriptorButtons.

	aButton _ SimpleButtonMorph new.
	indent _ 110.
	aButton target: EToySystem; actionSelector: #openImagineeringStudio; label: 'Imagineering Studio' font: aFont; position: (indent + 12) @ 16; color: Color lightBlue darker.
	aWorld addMorph: aButton.

	aButton _ SimpleButtonMorph new.
	aButton target: EToySystem; actionSelector: #newEToy; label: 'New E-Toy' font: aFont; position: (indent + 35) @ 40; color: Color lightYellow.
	aWorld addMorph: aButton.

	aButton _ SimpleButtonMorph new.
	aButton target: EToySystem; actionSelector: #loadEToyFromDisk; label: 'Load eToy from disk' font: aFont; position: (indent + 8) @ 64; color: Color lightGreen.
	aWorld addMorph: aButton.

	aButton _ SimpleButtonMorph new.
	aButton target: Utilities; actionSelector: #absorbUpdatesFromServer; label: 'Update Code from Server' font: aFont; position: indent @ 88; color: Color lightRed.
	aWorld addMorph: aButton.

	aButton _ SimpleButtonMorph new.
	aButton target: WorldMorph; actionSelector: #openWithStandardPartsBinShowing; label: 'New Morphic World' font: aFont; position:  (indent + 20) @ 116; color: Color lightBlue.
	aWorld addMorph: aButton.

	aButton _ SimpleButtonMorph new.
	aButton target: ScriptingSystem; actionSelector: #reclaimSpace; label: 'Reclaim Space' font: aFont; position: (indent + 28) @ 144; color: Color lightYellow.
	aWorld addMorph: aButton.

	aButton _ SimpleButtonMorph new.
	aButton target: EToySystem; actionSelector: #loadEToyFromServer; label: 'Load EToy from Server' font: aFont; position: indent @ 172; color: Color lightGray.
	aWorld addMorph: aButton.

	position _ 12 @ 10.
	#(
	('KidsMode'			'KidsModeOn'			'KidsModeOff'			toggleKidsMode				kidsMode)
	('CmdDot'			'CmdDotEnabled'			'CmdDotDisabled'			toggleCmdDot				cmdDotEnabled)
	('CautionClose'		'CautionCloseOn'			'CautionCloseOff'		toggleCautionBeforeClosing  	cautionBeforeClosing)
	('FullEToyGraphics'	'FullEToyGraphicsOn'	'FullEToyGraphicsOff'	toggleEToyGraphics			fullEToyGraphics))

	with: #(

'When on, new etoys will
be launched in kids mode,
with changes in handling of
cmd-click, option-click, text-
editibility, palettes,  etc.'

'When green, cmd-period is
used to interrupt processing and
bring up a Smalltalk debugger.
When red, cmd-period is disabled.'

'When on, Morphic windows annoy
you with a prompt before allowing you
to close them.  When off, they are
closed without hesitation'

'When on, etoys will have their full
graphics, such as the imagineers and the
cedar and kaya pictures.  When off, those
graphics are not included, saving lots
of time and space')

	do:
			[:q :helpString |
			aButton _ ToggleButtonMorph new setNameTo: q first.
			aButton target: EToyParameters.
			aButton onImage: (aDict at: q second);
				offImage: (aDict at: q third);
				pressedImage: nil;
				actionSelector: q fourth;
				stateSelector: q last;
				actWhen: #buttonDown;
				position: position; extent: (aDict at: q second) extent;
				setInitialState;  "Obtains it from target"
				setBalloonText: helpString.
			aWorld addMorph: aButton.
			position _ position + ( 0 @ (aButton height + 10))]

"	aButton _ SimpleButtonMorph new.
	aButton target: BalloonMorph; actionSelector: #chooseBalloonFont; label: 'Balloon Font' font: aFont; position: (indent + 28) @ 116; color: Color lightBrown.
	aWorld addMorph: aButton."