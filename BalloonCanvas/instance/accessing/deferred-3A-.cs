deferred: aBoolean
	deferred == aBoolean ifTrue:[^self].
	self flush. "Force pending prims on screen"
	deferred _ aBoolean.
	engine ifNotNil:[engine deferred: aBoolean].