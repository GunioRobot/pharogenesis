stripNameFrom: aString
	"Picks out the name from:
		'Robert Robertson <rob@here.com>' => 'Robert Robertson'
	"

	| lessThan |
	lessThan _ aString indexOf: $<.
	^(aString copyFrom: 1 to: lessThan - 1) withBlanksTrimmed 