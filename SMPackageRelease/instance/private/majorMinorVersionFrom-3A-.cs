majorMinorVersionFrom: aVersionName

	| start |
	start := aVersionName indexOf: $..
	start = 0 ifTrue: [^ aVersionName].
	aVersionName size = start ifTrue: [^ aVersionName].
	start + 1 to: aVersionName size do: [:i |
		(aVersionName at: i) isDigit ifFalse: [^aVersionName copyFrom: 1 to: i - 1]].
	^aVersionName