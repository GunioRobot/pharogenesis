baseName
	"returns the last component stripped of its extension"

	| baseName i |
	baseName _ self pathComponents last.
	i _ baseName findLast: [:c | c = $.].
	^i = 0
		ifTrue: [baseName]
		ifFalse: [baseName copyFrom: 1 to: i-1].
