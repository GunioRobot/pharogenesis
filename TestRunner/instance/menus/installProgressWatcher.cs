installProgressWatcher
	| win host |
	win _ self dependents first.
	host _ win submorphs first.
	progress _ ProgressMorph label: 'Test progress'.
	progress
		borderWidth: 0;
		position: host position;
		extent: host extent;
		color: Color transparent;
		wrapCentering: #center;
		hResizing: #spaceFill;
		vResizing: #spaceFill.
	win
		addMorph: progress 
		frame: (0.0 @ 0.7 extent: 1.0 @ 0.3).
