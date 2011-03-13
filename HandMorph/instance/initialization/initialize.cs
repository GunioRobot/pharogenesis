initialize
	super initialize.
	self initForEvents.
	keyboardFocus _ nil.
	mouseFocus _ nil.
	bounds _ 0@0 extent: Cursor normal extent.
	userInitials _ ''.
	damageRecorder _ DamageRecorder new.
	cachedCanvasHasHoles _ false.
	temporaryCursor _ temporaryCursorOffset _ nil.
	self initForEvents.