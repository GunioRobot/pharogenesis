readFloat
	| intVal fracVal expVal char s floatValue fracExp negative |
	self backup.
	s := ReadWriteStream on: (String new: 10).
	fracVal := 0.0.
	"Read sign"
	negative _ self peekChar = $-.
	negative ifTrue:[self skip: 1].
	"Read integer part"
	(self peekChar = $.) 
		ifTrue:[intVal := 0]
		ifFalse:[intVal := self readInt32].
	"Read fraction part"
	self peekChar = $. ifTrue:[
		self skip: 1.
		fracExp := 1.
		[(char := self nextChar) isDigit] whileTrue:[s nextPut: char. fracExp := fracExp * 10].
		self skip: -1.
		s reset.
		fracVal := Integer readFrom: s.
		fracVal := fracVal asFloat / fracExp asFloat.
	].
	"Check for exponent"
	self peekChar asLowercase = $e ifTrue:[
		self skip: 1.
		expVal := self readInt32.
	] ifFalse:[expVal := 1].
	floatValue := intVal asFloat + fracVal.
	expVal = 1 ifFalse:[ floatValue := floatValue raisedTo: expVal].
	self discard.
	negative
		ifTrue:[^0.0 - floatValue]
		ifFalse:[^floatValue]