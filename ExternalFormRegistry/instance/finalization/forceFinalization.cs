forceFinalization
	self associationsDo:[:assoc|
		assoc key isNil ifTrue:[assoc value destroy].
	].
	super finalizeValues.