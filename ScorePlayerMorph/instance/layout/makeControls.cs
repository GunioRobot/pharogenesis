makeControls

	| b r reverbSwitch repeatSwitch |
	b _ SimpleButtonMorph new
		target: self;
		borderColor: #raised;
		borderWidth: 2;
		color: color.
	r _ AlignmentMorph newRow.
	r color: b color; borderWidth: 0; layoutInset: 0.
	r hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	r addMorphBack: (b fullCopy label: '<>'; actWhen: #buttonDown;
														actionSelector: #invokeMenu).
	r addMorphBack: (b fullCopy label: 'Piano Roll';		actionSelector: #makePianoRoll).
	r addMorphBack: (b fullCopy label: 'Rewind';		actionSelector: #rewind).
	b target: scorePlayer.
	r addMorphBack: (b fullCopy label: 'Play';			actionSelector: #resumePlaying).
	r addMorphBack: (b fullCopy label: 'Pause';			actionSelector: #pause).
	reverbSwitch _ SimpleSwitchMorph new
		offColor: color;
		onColor: (Color r: 1.0 g: 0.6 b: 0.6);
		borderWidth: 2;
		label: 'Reverb Disable';
		actionSelector: #disableReverb:;
		target: scorePlayer;
		setSwitchState: SoundPlayer isReverbOn not.
	r addMorphBack: reverbSwitch.
	scorePlayer ifNotNil:
		[repeatSwitch _ SimpleSwitchMorph new
			offColor: color;
			onColor: (Color r: 1.0 g: 0.6 b: 0.6);
			borderWidth: 2;
			label: 'Repeat';
			actionSelector: #repeat:;
			target: scorePlayer;
			setSwitchState: scorePlayer repeat.
		r addMorphBack: repeatSwitch].
	b target: self.
	^ r
