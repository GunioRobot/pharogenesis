initialize

	| displayer dataMorph |

	super initialize.
	hasFocus _ true.
	currentKeyDown _ Set new.
	upDownCodes _ Dictionary new.
	upDownCodes
		at: 126 put: #up;		"arrow keys on the mac"
		at: 125 put: #down;
		at: 123 put: #out;
		at: 124 put: #in.
	color _ Color lightBlue.
	self 
		extent: 40@40;
		vResizing: #rigid;
		hResizing: #spaceFill;
		borderWidth: 0;
		borderColor: Color transparent;
		setBalloonText: 'Drag in here to zoom, tilt and pan the page above'.
	dataMorph _ AlignmentMorph newColumn.
	dataMorph 
		color: Color yellow;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap.
	dataMorph on: #mouseDown send: #grabCameraPositionEvent:morph: to: self.
 	displayer _ UpdatingStringMorph new
		getSelector: #cameraPointRounded;
		target: self;
		growable: true;
		putSelector: nil.
	dataMorph addMorph: displayer lock.

 	displayer _ UpdatingStringMorph new
		getSelector: #cameraScale;
		target: self;
		growable: true;
		floatPrecision: 0.001;
		putSelector: nil.
	dataMorph addMorph: displayer lock.
	self addMorph: dataMorph.

