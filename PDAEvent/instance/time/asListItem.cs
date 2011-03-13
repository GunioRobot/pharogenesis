asListItem

	| timeString ampm |
	time ifNil: [^ '-- ' , (description copyUpTo: Character cr) , ' --'].
	timeString _ time printString.
	ampm _ timeString last: 2.
	^ (timeString allButLast: 3) , ampm , '  ' , (description copyUpTo: Character cr)