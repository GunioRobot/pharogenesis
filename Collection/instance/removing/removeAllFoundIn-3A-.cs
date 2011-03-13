removeAllFoundIn: aCollection 
	"Remove each element of aCollection which is present in the receiver from the receiver"

	aCollection do: [:each | self remove: each ifAbsent: []].
	^aCollection