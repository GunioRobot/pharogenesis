readFloat
	| intVal fracVal expVal char s floatValue fracExp negative aStream |
	self backup.
	aStream _ ReadStream on: (theStream next: 100) asString.
	s := ReadWriteStream on: (String new: 10).
	fracVal := 0.0.
	"Read sign"
	negative _ aStream peek = $-.
	negative ifTrue:[aStream skip: 1].
	"Read integer part"
	(aStream peek = $.) 
		ifTrue:[intVal := 0]
		ifFalse:[intVal := self readInt32From: aStream].
	intVal ifNil:[self restore. ^nil].
	"Read fraction part"
	aStream peek =  $. ifTrue:[
		aStream skip: 1.
		fracExp := 1.
		[(char := aStream next) isDigit] whileTrue:[s nextPut: char. fracExp := fracExp * 10].
		aStream skip: -1.
		s reset.
		fracVal := Integer readFrom: s.
		fracVal := fracVal asFloat / fracExp asFloat.
	].
	"Check for exponent"
	aStream peek asLowercase = $e ifTrue:[
		aStream skip: 1.
		expVal := self readInt32From: aStream.
	] ifFalse:[expVal := 1].
	floatValue := intVal asFloat + fracVal.
	expVal = 1 ifFalse:[ floatValue := floatValue raisedTo: expVal].
	self discardTo: aStream position.
	negative
		ifTrue:[^0.0 - floatValue]
		ifFalse:[^floatValue]