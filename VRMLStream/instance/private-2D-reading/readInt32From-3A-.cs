readInt32From: aStream
	| negative intVal char |
	negative := false.
	"Read sign"
	char := aStream next.
	char isDigit ifFalse:[
		char = $- ifTrue:[
			negative := true
		] ifFalse:[
			char = $+ ifFalse:[^nil]].
		char := aStream next].
	(char = $0 and:[aStream peek asLowercase = $x]) ifTrue:[
		"hexadecimal notation"
		aStream skip: 1.
		intVal := self readInteger: 16 from: aStream.
	] ifFalse:[
		"decimal notation"
		aStream skip: -1.
		intVal := self readInteger: 10 from: aStream.
	].
	^negative
		ifTrue:[0 - intVal]
		ifFalse:[intVal]