remove: oldObject ifAbsent: exceptionBlock 
	"Refer to the comment in Collection|remove:ifAbsent:."

	| count |
	(self includes: oldObject)
		ifTrue: [(count _ contents at: oldObject) = 1
				ifTrue: [contents removeKey: oldObject]
				ifFalse: [contents at: oldObject put: count - 1]]
		ifFalse: [^exceptionBlock value].
	^oldObject