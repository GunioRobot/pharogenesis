getSuffix: aString
	| i |
	i _ aString findLast: [:each | $. = each].
	^ i = 0
		ifTrue: ['']
		ifFalse: [aString copyFrom: i + 1 to: aString size]