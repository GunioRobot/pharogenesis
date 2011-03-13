isFontAvailable
	| encoding f |
	encoding := self leadingChar + 1.
	f _ TextStyle defaultFont.
	f isFontSet ifTrue: [
		f fontArray
			at: encoding
			ifAbsent: [^ false].
		^ true
	].
	encoding = 1 ifTrue: [^ true].
	f fallbackFont isFontSet ifFalse: [^false].
	f fallbackFont fontArray
		at: encoding
		ifAbsent: [^ false].
	^ true
