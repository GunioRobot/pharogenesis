builtin: sel
	"Answer true if the given selector is one of the builtin selectors."

	((sel = #longAt:) or: [(sel = #longAt:put:) or: [sel = #error:]]) ifTrue: [ ^true ].
	((sel = #byteAt:) or: [sel = #byteAt:put:]) ifTrue: [ ^true ].
	^translationDict includesKey: sel