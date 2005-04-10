> aString 
	"Answer whether the receiver sorts after aString.
	The collation order is simple ascii (with case differences)."
	^(self compare: aString caseSensitive: true) = 3