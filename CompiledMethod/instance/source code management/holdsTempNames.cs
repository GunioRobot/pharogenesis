holdsTempNames
	"Are tempNames stored in trailer bytes"

	| flagByte |
	flagByte := self last.
	(flagByte = 0 or: [flagByte = 251 "some source-less methods have flag = 251, rest = 0"
			and: [(1 to: 3) allSatisfy: [:i | (self at: self size - i) = 0]]])
		ifTrue: [^ false].  "No source pointer & no temp names"
	flagByte < 252 ifTrue: [^ true].  "temp names compressed"
	^ false	"Source pointer"
