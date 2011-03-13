withBlanksTrimmed
	"Return a copy of the receiver from which leading and trailing blanks have been trimmed.   This is a quick-and-dirty, sledge-hammer implementation; improvements welcomed.  1/18/96 sw"

	| firstNonBlank lastNonBlank |

	firstNonBlank _ 1.
	[firstNonBlank < self size and: [(self at: firstNonBlank) isSeparator]] whileTrue:
		[firstNonBlank _ firstNonBlank + 1].
	
	lastNonBlank _ self size.
	[lastNonBlank > 0 and: [(self at: lastNonBlank) isSeparator]] whileTrue:
		[lastNonBlank _ lastNonBlank - 1].
	^ lastNonBlank < firstNonBlank
		ifTrue:
			['']
		ifFalse:
			[self copyFrom: firstNonBlank to: lastNonBlank]

"  ' abc  d   ' withBlanksTrimmed"