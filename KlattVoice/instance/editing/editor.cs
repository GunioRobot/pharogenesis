editor
	^ KlattFrameMorph new
		frame: self patternFrame edit: #(flutter jitter shimmer diplophonia ro rk ra turbulence gain);
		addSliderForParameter: #breathiness target: self min: 0.0 max: 1.0 description: 'Amount of breathiness';
		addSliderForParameter: #tract target: self min: 10.0 max: 20.0 description: 'Vocal tract length (average male=17.3, average female=14.4)'