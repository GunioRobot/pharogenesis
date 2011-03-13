>= aString 
	"Answer whether the receiver collates after aString or is the same as 
	aString. The collation sequence is ascii with case differences ignored."

	^(self compare: aString) >= 2