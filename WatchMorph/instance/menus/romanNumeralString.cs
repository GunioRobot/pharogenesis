romanNumeralString
	"Answer a string governing the roman-numerals checkbox"
	^ (romanNumerals
		ifTrue: ['<on>']
		ifFalse: ['<off>'])
		, 'roman numerals' translated