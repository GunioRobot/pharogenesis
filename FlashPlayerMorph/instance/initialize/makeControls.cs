makeControls

	| bb r loopSwitch |
	r := AlignmentMorph newRow.
	r hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	bb := SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Rewind';		actionSelector: #rewind).
	bb := SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Play';		actionSelector: #startPlaying).
	bb := SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Pause';		actionSelector: #stopPlaying).
	bb := SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Next';		actionSelector: #stepForward).
	bb := SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Prev';		actionSelector: #stepBackward).
	loopSwitch := SimpleSwitchMorph new
		borderWidth: 2;
		label: 'Loop';
		actionSelector: #loopFrames:;
		target: self;
		setSwitchState: self loopFrames.
	r addMorphBack: loopSwitch.
	loopSwitch := SimpleSwitchMorph new
		borderWidth: 2;
		label: 'Defer';
		actionSelector: #toggleDeferred;
		target: self;
		setSwitchState: self deferred.
	r addMorphBack: loopSwitch.
	bb := SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Fastest'; 	actionSelector: #drawFastest).
	bb := SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Medium';	actionSelector: #drawMedium).
	bb := SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: 'Nicest';		actionSelector: #drawNicest).
	bb := SimpleButtonMorph new target: self; borderColor: #raised;
				borderWidth: 2.
	r addMorphBack: (bb label: '+10';		actionSelector: #jump10).
	^ self world activeHand attachMorph: r