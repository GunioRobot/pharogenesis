edit
	| answer buttons |
	answer _ (self findAVoice: KlattVoice) editor.
	buttons _ AlignmentMorph new orientation: #horizontal; color: answer color.
	buttons
		addMorphFront: (SimpleButtonMorph new target: self; actWhen: #buttonDown; actionSelector:  #newHead; labelString: 'new head');
		addMorphFront: (SimpleButtonMorph new target: self; actWhen: #buttonDown; actionSelector:  #saySomething; labelString: 'test').
	answer
		addSliderForParameter: #speed target: self min: 0.1 max: 2.0 description: 'Speed';
		addSliderForParameter: #loudness target: self min: 0.0 max: 1.0 description: 'Loudness';
		addSliderForParameter: #range target: self min: 0.0 max: 1.0 description: 'Pitch Range';
		addSliderForParameter: #pitch target: self min: 20.0 max: 800.0 description: 'Pitch';
		addMorphFront: buttons;
		openInWorld