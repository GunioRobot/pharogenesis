advance
	| this |
	prevMark _ hereMark.
	prevEnd _ hereEnd.
	this _ here.
	here _ token.
	hereType _ tokenType.
	hereMark _ mark.
	hereEnd _ source position - (source atEnd ifTrue: [hereChar == 30 asCharacter ifTrue: [0] ifFalse: [1]] ifFalse: [2]).
	self scanToken.
	"Transcript show: 'here: ', here printString, ' mark: ', hereMark printString, ' end: ', hereEnd printString; cr."
	^this