wantsHaloFromClick
	(owner isSystemWindow) ifTrue: [^ false].
	self paintBoxOrNil ifNotNil: [^ false].
	^ true.
