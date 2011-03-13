printOn: aStream format: formatArray 
	"Print a description of the receiver on aStream using the format denoted 
	by the argument, formatArray:
		#(item item item sep monthfmt yearfmt twoDigits)
		items:  1=day  2=month  3=year  will appear in the order given,
		separated by sep which is eaither an ascii code or character.
		monthFmt:  1=09  2=Sep  3=September
		yearFmt:  1=1996  2=96
		digits:  (missing or)1=9  2=09.
	See the examples in printOn: and mmddyy"
	| monthIndex element monthFormat twoDigits monthDay |
	twoDigits _ formatArray size > 6 and: [(formatArray at: 7) > 1].
	monthIndex _ self monthIndex.
	1 to: 3 do: 
		[:elementIndex | 
		element _ formatArray at: elementIndex.
		element = 1 ifTrue:
			[monthDay _ day - self firstDayOfMonth + 1.
			twoDigits & (monthDay < 10) ifTrue: [aStream nextPutAll: '0'].
				monthDay printOn: aStream].
		element = 2 ifTrue: 
			[monthFormat _ formatArray at: 5.
			monthFormat = 1 ifTrue:
				[twoDigits & (monthIndex < 10) ifTrue: [aStream nextPutAll: '0'].
				monthIndex printOn: aStream].
			monthFormat = 2 ifTrue:
				[aStream nextPutAll: ((MonthNames at: monthIndex)
												copyFrom: 1 to: 3)].
			monthFormat = 3 ifTrue:
				[aStream nextPutAll: (MonthNames at: monthIndex)]].
		element = 3 ifTrue: 
			[(formatArray at: 6) = 1
				ifTrue: [year printOn: aStream]
				ifFalse: [twoDigits & ((year \\ 100) < 10)
							ifTrue: [aStream nextPutAll: '0'].
						(year \\ 100) printOn: aStream]].
		elementIndex < 3 ifTrue: 
			[(formatArray at: 4) ~= 0 
				ifTrue: [aStream nextPut: (formatArray at: 4) asCharacter]]]