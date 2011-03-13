hasLiteralThorough: literal
	"Answer true if literal is identical to any literal in this array, even if imbedded in further array structures or closure methods"

	| lit |
	1 to: self size do: [:index |
		(lit := self at: index) == literal ifTrue: [^ true].
		(lit hasLiteralThorough: literal) ifTrue: [^ true]].
	^ false