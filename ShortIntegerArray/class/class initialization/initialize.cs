initialize
	"ShortIntegerArray initialize"
	Smalltalk addToStartUpList: self after: Delay.
	LastSaveOrder _ self new: 2.
	LastSaveOrder at: 1 put: 42.
	LastSaveOrder at: 2 put: 13.