indexOfAnyOf: aCharacterSet startingAt: start ifAbsent: aBlock 
	"returns the index of the first character in the given set, starting from start "
	
	| ans |
	ans := self isWideString
				ifTrue: ["Fallback to naive implementation"
					self class
						findFirstInString: self
						inCharacterSet: aCharacterSet
						startingAt: start]
				ifFalse: ["We know we contain only byte characters
						So use a byteArrayMap opimized for primitive call"
					self class
						findFirstInString: self
						inSet: aCharacterSet byteArrayMap
						startingAt: start].
	ans = 0
		ifTrue: [^ aBlock value]
		ifFalse: [^ ans]