changeMaxMessageCount
	| countString count |
	countString _ FillInTheBlank request: 'Maximum number of messages displayed?' initialAnswer: self class messageCountLimit printString.
	countString isEmpty
		ifTrue: [^ self].
	count _ Integer
				readFrom: (ReadStream on: countString).
	count _ count max: 10.
	count _ count min: 500.
	"Arbitrary. We could calculate the real upper bound."
	self class messageCountLimit: count.
	self setCategory: currentCategory