nextFromStream: aStream

	| character1 character2 readBOM charValue |
	aStream isBinary ifTrue: [^ aStream basicNext].
	character1 := aStream basicNext.
	character1 isNil ifTrue: [^ nil].
	character2 := aStream basicNext.
	character2 isNil ifTrue: [^ nil].

	readBOM := false.
	(character1 asciiValue = 16rFF and: [character2 asciiValue = 16rFE]) ifTrue: [
		self useByteOrderMark: true.
		self useLittleEndian: true.
		readBOM := true.
	].
	(character1 asciiValue = 16rFE and: [character2 asciiValue = 16rFF]) ifTrue: [
		self useByteOrderMark: true.
		self useLittleEndian: false.
		readBOM := true.
	].

	readBOM ifTrue: [
		character1 := aStream basicNext.
		character1 isNil ifTrue: [^ nil].
		character2 := aStream basicNext.
		character2 isNil ifTrue: [^ nil].
	].

	self useLittleEndian ifTrue: [
		charValue := character2 charCode << 8 + character1 charCode.
	] ifFalse: [
		charValue := character1 charCode << 8 + character2 charCode.
	].

	^ self charFromStream: aStream withFirst: charValue.
