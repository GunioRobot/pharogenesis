initialize
"initialize the state of the receiver"
	super initialize.
""
	edgeToAdhereTo _ #left.
	flapShowing _ false.
	slidesOtherObjects _ false.
	popOutOnDragOver _ false.
	popOutOnMouseOver _ false.
	inboard _ false.
	dragged _ false