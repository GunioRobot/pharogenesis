charactersExactlyMatching: aString
	"Do a character-by-character comparison between the receiver and aString; return the index of the final character that matched exactly.  4/29/96 sw"

	| count |
	count _ self size min: aString size.
	count == 0 ifTrue: [^ 0].
	1 to: count do:
		[:i | (self at: i) == (aString at: i) ifFalse: [^ i - 1]] .
	^ count