next: n into: aString startingAt: startIndex
	"Read n bytes into the given string.
	Return aString or a partial copy if less than
	n elements have been read."
	| count |
	count _ self primRead: fileID into: aString
				startingAt: startIndex count: n.
	count = n
		ifTrue:[^aString]
		ifFalse:[^aString copyFrom: 1 to: startIndex+count-1]