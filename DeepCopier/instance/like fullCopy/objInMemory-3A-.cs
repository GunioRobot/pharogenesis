objInMemory: ClassSymbol
	| cls |
	"Test if this global is in memory and return it if so."

	cls _ Smalltalk at: ClassSymbol ifAbsent: [^ nil].
	^ cls isInMemory ifTrue: [cls] ifFalse: [nil].