makeControls

	| b r loopSwitch |
	b _ SimpleButtonMorph new
		target: self;
		borderColor: #raised;
		borderWidth: 2.
	r _ AlignmentMorph newRow.
	r hResizing: #shrinkWrap; vResizing: #shrinkWrap; extent: 5@5.
	r addMorphBack: (b fullCopy label: 'Rewind';		actionSelector: #rewind).
	r addMorphBack: (b fullCopy label: 'Play';			actionSelector: #startPlaying).
	r addMorphBack: (b fullCopy label: 'Pause';			actionSelector: #stopPlaying).
	r addMorphBack: (b fullCopy label: 'Next';			actionSelector: #stepForward).
	r addMorphBack: (b fullCopy label: 'Prev';			actionSelector: #stepBackward).
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
	r addMorphBack: (b fullCopy label: 'Fastest'; 	actionSelector: #drawFastest).
	r addMorphBack: (b fullCopy label: 'Medium';	actionSelector: #drawMedium).
	r addMorphBack: (b fullCopy label: 'Nicest';		actionSelector: #drawNicest).
	r addMorphBack: (b fullCopy label: '+10';		actionSelector: #jump10).
	b target: self.
	^ self world activeHand attachMorph: r