autoLineLayout
	| layout |
	layout _ self layoutPolicy ifNil:[^false].
	layout isTableLayout ifFalse:[^false].
	self listDirection == #leftToRight ifFalse:[^false].
	self wrapDirection == #topToBottom ifFalse:[^false].
	^true