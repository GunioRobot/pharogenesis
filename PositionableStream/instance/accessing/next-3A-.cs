next: anInteger 
	"Answer the next anInteger elements of the receiver."

	| newArray |
	newArray _ collection species new: anInteger.
	1 to: anInteger do: [:index | newArray at: index put: self next].
	^newArray