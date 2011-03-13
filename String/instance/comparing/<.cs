< aString 
	"Answer whether the receiver collates before aString. The collation 
	sequence is ascii with case differences ignored."

	^(self compare: aString) = 1