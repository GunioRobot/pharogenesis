= aString 
	"Answer whether the receiver sorts equally as aString.
	The collation order is simple ascii (with case differences)."
	aString isString ifFalse:[^false].
	^(self compare: aString caseSensitive: true) = 2