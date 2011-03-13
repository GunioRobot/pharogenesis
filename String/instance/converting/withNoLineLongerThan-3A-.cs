withNoLineLongerThan: aNumber
	"Answer a string with the same content as receiver, but rewrapped so that no line has more characters than the given number"
	| listOfLines currentLast currentStart resultString putativeLast putativeLine crPosition |
	aNumber isNumber not | (aNumber < 1) ifTrue: [self error: 'too narrow'].
	listOfLines := OrderedCollection new.
	currentLast := 0.
	[currentLast < self size] whileTrue:
		[currentStart := currentLast + 1.
		putativeLast := (currentStart + aNumber - 1) min: self size.
		putativeLine := self copyFrom: currentStart to: putativeLast.
		(crPosition := putativeLine indexOf: Character cr) > 0 ifTrue:
			[putativeLast := currentStart + crPosition - 1.
			putativeLine := self copyFrom: currentStart to: putativeLast].
		currentLast := putativeLast == self size
			ifTrue:
				[putativeLast]
			ifFalse:
				[currentStart + putativeLine lastSpacePosition - 1].
		currentLast <= currentStart ifTrue:
			["line has NO spaces; baleout!"
			currentLast := putativeLast].
		listOfLines add: (self copyFrom: currentStart to: currentLast) withBlanksTrimmed].

	listOfLines size > 0 ifFalse: [^ ''].
	resultString := listOfLines first.
	2 to: listOfLines size do:
		[:i | resultString := resultString, String cr, (listOfLines at: i)].
	^ resultString

"#(5 7 20) collect:
	[:i | 'Fred the bear went down to the brook to read his book in silence' withNoLineLongerThan: i]"