initialize
	super initialize.
	self initForEvents.
	keyboardFocus _ nil.
	mouseOverMorphs _ OrderedCollection new.
	dragOverMorphs _ OrderedCollection new.
	bounds _ 0@0 extent: Cursor normal extent.
	userInitials _ ''.
	damageRecorder _ DamageRecorder new.
	cachedCanvasHasHoles _ false.
	grid _ 4@4.
	gridOn _ false.
	remoteConnections _ OrderedCollection new.
	lastEventTransmitted _ MorphicEvent new.
	temporaryCursor _ temporaryCursorOffset _ nil
