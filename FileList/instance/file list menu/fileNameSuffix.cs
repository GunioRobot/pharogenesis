fileNameSuffix

	| name i |
	name _ self fullName.
	i _ name findLast: [:c | c = $.].
	i = 0 ifTrue: [^ ''].
	^ name copyFrom: i + 1 to: name size
