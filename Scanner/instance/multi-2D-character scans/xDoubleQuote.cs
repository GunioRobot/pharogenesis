xDoubleQuote
	"Collect a comment."

	| aStream stopChar |
	stopChar _ 30 asCharacter.
	aStream _ WriteStream on: (String new: 200).
	self step.
	[aStream nextPut: self step. hereChar == $"]
		whileFalse: 
			[(hereChar == stopChar and: [source atEnd])
				ifTrue: [^self offEnd: 'Unmatched comment quote']].
	self step.
	currentComment == nil
		ifTrue: [currentComment _ OrderedCollection with: aStream contents]
		ifFalse: [currentComment add: aStream contents].
	self scanToken