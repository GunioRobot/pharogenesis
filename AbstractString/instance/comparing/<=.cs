<= aString 
	"Answer whether the receiver sorts before or equal to aString.
	The collation order is simple ascii (with case differences)."
	^(self compare: aString caseSensitive: true) <= 2