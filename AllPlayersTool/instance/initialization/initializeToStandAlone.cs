initializeToStandAlone
	"Initialize the receiver"

	super initializeToStandAlone.
	self layoutPolicy: TableLayout new;
		listDirection: #topToBottom;
		hResizing: #spaceFill;
		extent: 1@1;
		vResizing: #spaceFill;
		rubberBandCells: true;
		yourself.

	self initializeFor: self currentWorld presenter