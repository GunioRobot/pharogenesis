hasChanges

	self sourceCode isEmpty ifFalse:[^true].
	self organization hasNoComment ifFalse:[^true].
	definition isNil ifFalse:[^true].
	metaClass isNil ifFalse:[^metaClass hasChanges].
	^false