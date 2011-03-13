fileOutUnnumberedChangeSets
	"File out all nonempty change sets whose names do not start with numbers, without checking for slips"

	| aList |
	"Utilities fileOutUnnumberedChangeSets"

	aList _ ChangeSorter allChangeSetNames reject:
		[:aName | ((aName startsWithDigit or: [(ChangeSorter changeSetNamed: aName) isEmpty]) or: [aName beginsWith: 'Play With Me']) or: [aName = 'MakeInternal']].
	Preferences setFlag: #checkForSlips toValue: false during: 
		[self fileOutChangeSetsNamed: aList asSortedArray]