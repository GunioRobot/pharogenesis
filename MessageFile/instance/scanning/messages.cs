messages
	| messages |
	messages _ OrderedCollection new.
	self messagesDo: [ :deleted :msgID :msgBody | messages add: {deleted. msgID. msgBody} ].
	^ messages