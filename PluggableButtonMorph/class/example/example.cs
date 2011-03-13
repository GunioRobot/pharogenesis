example
	"PluggableButtonMorph example"

	| s1 s2 s3 b1 b2 b3 row |
	s1 _ Switch new.
	s2 _ Switch new turnOn.
	s3 _ Switch new.
	s2 onAction: [s3 turnOff].
	s3 onAction: [s2 turnOff].
	b1 _ (PluggableButtonMorph on: s1 getState: #isOn action: #switch) label: 'S1'.
	b2 _ (PluggableButtonMorph on: s2 getState: #isOn action: #turnOn) label: 'S2'.
	b3 _ (PluggableButtonMorph on: s3 getState: #isOn action: #turnOn) label: 'S3'.
	row _ AlignmentMorph newRow
		hResizing: #spaceFill;
		vResizing: #spaceFill;
		addAllMorphs: (Array with: b1 with: b2 with: b3);
		extent: 120@35.
	^ row
