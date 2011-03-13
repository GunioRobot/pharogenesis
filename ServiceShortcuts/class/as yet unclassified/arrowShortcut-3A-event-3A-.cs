arrowShortcut: str event: event 
	| key s |
	key _ event keyCharacter caseOf: {
				[Character arrowDown] -> ['down'].
				[Character arrowUp] -> ['up'].
				[Character arrowLeft] -> ['left'].
				[Character arrowRight] -> ['right']}.
	s _ self map
				at: str , key
				ifAbsent: [^ self].
	s serviceOrNil
		ifNotNilDo: [:sv | sv execute.
	event wasHandled: true]