characterSetFrom: setSpec
	"<setSpec> is what goes between the brackets in a charset regex
	(a String). Make a string containing all characters the spec specifies.
	Spec is never empty."
	| negated spec |
	spec := setSpec readStream.
	spec peek = $^
		ifTrue: 	[negated := true.
				spec next]
		ifFalse:	[negated := false].
	^RxsCharSet new
		initializeElements: (RxCharSetParser on: spec) parse
		negated: negated