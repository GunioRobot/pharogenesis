withNoLineLongerThan: aNumber
	"Answer a string with the same content as receiver, but rewrapped so that no line has more characters than the given number"
	| listOfLines currentLast currentStart resultString putativeLast putativeLine crPosition |
	aNumber isNumber not | (aNumber < 1) ifTrue: [self error: 'too narrow'].
	listOfLines _ OrderedCollection new.
	currentLast _ 0.
	[currentLast < self size] whileTrue:
		[currentStart _ currentLast + 1.
		putativeLast _ (currentStart + aNumber - 1) min: self size.
		putativeLine _ self copyFrom: currentStart to: putativeLast.
		(crPosition _ putativeLine indexOf: Character cr) > 0 ifTrue:
			[putativeLast _ currentStart + crPosition - 1.
			putativeLine _ self copyFrom: currentStart to: putativeLast].
		currentLast _ putativeLast == self size
			ifTrue:
				[putativeLast]
			ifFalse:
				[currentStart + putativeLine lastSpacePosition - 1].
		currentLast <= currentStart ifTrue:
			["line has NO spaces; baleout!"
			currentLast _ putativeLast].
		listOfLines add: (self copyFrom: currentStart to: currentLast) withBlanksTrimmed].

	listOfLines size > 0 ifFalse: [^ ''].
	resultString _ listOfLines first.
	2 to: listOfLines size do:
		[:i | resultString _ resultString, String cr, (listOfLines at: i)].
	^ resultString

"#(5 7 20) collect:
	[:i | 'Fred the bear went down to the brook to read his book in silence' withNoLineLongerThan: i]"