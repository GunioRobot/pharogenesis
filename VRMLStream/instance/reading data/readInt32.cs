readInt32
	| negative intVal char |
	self backup.
	negative := false.
	"Read sign"
	char := self nextChar.
	char isDigit ifFalse:[
		char = $- ifTrue:[
			negative := true
		] ifFalse:[
			char = $+ ifFalse:[ self restore. ^nil]].
		char := self nextChar].
	(char = $0 and:[self peekChar asLowercase = $x]) ifTrue:[
		"hexadecimal notation"
		self skip: 1.
		intVal := self readInteger: 16.
	] ifFalse:[
		"decimal notation"
		self skip: -1.
		intVal := self readInteger: 10.
	].
	self discard.
	^negative
		ifTrue:[0 - intVal]
		ifFalse:[intVal]