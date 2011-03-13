shortcut: str event: event 
	| s |
	Transcript cr.
	s := self map
				at: str , event keyCharacter asString
				ifAbsent: [^ self].
	(s beginsWith: '[') ifTrue: [^ (Compiler evaluateUnloggedForSelf:  s) value].
	s serviceOrNil
		ifNotNil: [:sv | sv execute.
	event wasHandled: true]