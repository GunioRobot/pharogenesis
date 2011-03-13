makeControls

	| b r reverbSwitch repeatSwitch |
	b _ SimpleButtonMorph new
		target: self;
		borderColor: #raised;
		borderWidth: 2;
		color: color.
	r _ AlignmentMorph newRow.
	r color: b color; borderWidth: 0; inset: 0.
	r hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	r addMorphBack: (b fullCopy label: 'Reset Insts.';		actionSelector: #reset).
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
	repeatSwitch _ SimpleSwitchMorph new
		offColor: color;
		onColor: (Color r: 1.0 g: 0.6 b: 0.6);
		borderWidth: 2;
		label: 'Repeat';
		actionSelector: #repeat:;
		target: scorePlayer;
		setSwitchState: scorePlayer repeat.
	r addMorphBack: repeatSwitch.
	b target: self.
	^ r
