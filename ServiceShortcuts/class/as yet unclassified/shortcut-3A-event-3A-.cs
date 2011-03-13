shortcut: str event: event 
	| s |
	Transcript cr.
	s := self map
				at: str , event keyCharacter asString
				ifAbsent: [^ self].
	(s startsWith: '[') ifTrue: [^ (Compiler evaluateUnloggedForSelf:  s) value].
	s serviceOrNil
		ifNotNilDo: [:sv | sv execute.
	event wasHandled: true]