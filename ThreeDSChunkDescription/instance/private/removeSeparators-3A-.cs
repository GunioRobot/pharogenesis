removeSeparators: aString
	"Remove leading and trailing separators"

	| start end |
	start := 1.
	end := aString size.
	[start <= end and: [(aString at: start) isSeparator]] whileTrue: [start := start + 1].
	[start < end and: [(aString at: end) isSeparator]] whileTrue: [end := end - 1].
	(start = 1 and: [end = aString size]) ifTrue: [^aString].
	start = end ifTrue: [^''].
	^aString copyFrom: start to: end