initialize
	super initialize.
	self initForEvents.
	keyboardFocus _ nil.
	mouseOverMorphs _ OrderedCollection new.
	bounds _ 0@0 extent: Cursor normal extent.
	userInitials _ ''.
	damageRecorder _ DamageRecorder new.
	grid _ 4@4.
	gridOn _ false.
	remoteConnections _ OrderedCollection new.
	lastEventTransmitted _ MorphicEvent new.
	mouseOverTimes _ Dictionary new
