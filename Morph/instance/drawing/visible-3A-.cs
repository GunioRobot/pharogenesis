visible: aBoolean
	extension ifNil: [aBoolean ifTrue: [^ self]].
	self visible == aBoolean ifTrue: [^ self].
	self assureExtension visible: aBoolean.
	self changed