at: key
	"Return page of a given key."

	^pages at: key asLowercase ifAbsent: [nil]