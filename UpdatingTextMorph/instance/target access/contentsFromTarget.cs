contentsFromTarget
	"private - answer the contents from the receiver's target"
	(target isNil
			or: [getSelector isNil])
		ifTrue: [^ self contents].
	""
	^ (target perform: getSelector) asString