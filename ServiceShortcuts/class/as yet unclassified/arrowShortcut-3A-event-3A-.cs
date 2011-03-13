arrowShortcut: str event: event 
	| key s |
	key := event keyCharacter caseOf: {
				[Character arrowDown] -> ['down'].
				[Character arrowUp] -> ['up'].
				[Character arrowLeft] -> ['left'].
				[Character arrowRight] -> ['right']}.
	s := self map
				at: str , key
				ifAbsent: [^ self].
	s serviceOrNil
		ifNotNil: [:sv | sv execute.
	event wasHandled: true]