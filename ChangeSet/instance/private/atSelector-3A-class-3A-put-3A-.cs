atSelector: selector class: class put: changeType
	| dict |
	(self isNew: class) ifTrue: [^self]. 	"Don't keep method changes for new classes"
	(selector==#DoIt) | (selector==#DoItIn:) ifTrue: [^self].
	(methodChanges at: class name
		ifAbsent: 
			[dict _ IdentityDictionary new.
			methodChanges at: class name put: dict.
			dict])
		at: selector put: changeType 