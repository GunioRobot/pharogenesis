makeControls

	| b r reverbSwitch onOffSwitch |
	b _ SimpleButtonMorph new
		target: self;
		borderColor: #raised;
		borderWidth: 2;
		color: color.
	r _ AlignmentMorph newRow.
	r color: b color; borderWidth: 0; inset: 0.
	r hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	r addMorphBack: (
		b fullCopy
			label: '<>';
			actWhen: #buttonDown;
			actionSelector: #invokeMenu).
	onOffSwitch _ SimpleSwitchMorph new
		offColor: color;
		onColor: (Color r: 1.0 g: 0.6 b: 0.6);
		borderWidth: 2;
		label: 'On';
		actionSelector: #toggleOnOff;
		target: self;
		setSwitchState: false.
	r addMorphBack: onOffSwitch.
	reverbSwitch _ SimpleSwitchMorph new
		offColor: color;
		onColor: (Color r: 1.0 g: 0.6 b: 0.6);
		borderWidth: 2;
		label: 'Reverb Disable';
		actionSelector: #disableReverb:;
		target: self;
		setSwitchState: SoundPlayer isReverbOn not.
	r addMorphBack: reverbSwitch.
	^ r
