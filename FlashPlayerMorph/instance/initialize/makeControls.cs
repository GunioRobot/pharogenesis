makeControls

	| bb r loopSwitch |
	r _ AlignmentMorph newRow.
	r hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	bb _ SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Rewind';		actionSelector: #rewind).
	bb _ SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Play';		actionSelector: #startPlaying).
	bb _ SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Pause';		actionSelector: #stopPlaying).
	bb _ SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Next';		actionSelector: #stepForward).
	bb _ SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Prev';		actionSelector: #stepBackward).
	loopSwitch _ SimpleSwitchMorph new
		borderWidth: 2;
		label: 'Loop';
		actionSelector: #loopFrames:;
		target: self;
		setSwitchState: self loopFrames.
	r addMorphBack: loopSwitch.
	loopSwitch _ SimpleSwitchMorph new
		borderWidth: 2;
		label: 'Defer';
		actionSelector: #toggleDeferred;
		target: self;
		setSwitchState: self deferred.
	r addMorphBack: loopSwitch.
	bb _ SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Fastest'; 	actionSelector: #drawFastest).
	bb _ SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Medium';	actionSelector: #drawMedium).
	bb _ SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Nicest';		actionSelector: #drawNicest).
	bb _ SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: '+10';		actionSelector: #jump10).
	^ self world activeHand attachMorph: r