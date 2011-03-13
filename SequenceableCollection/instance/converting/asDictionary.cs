asDictionary
	"Answer a Dictionary whose keys are string versions of my indices and whose values are my elements.  6/12/96 sw"

	| aDictionary |
	aDictionary _ Dictionary new.
	1 to: self size do:
		[:i | aDictionary add:
			(Association key: i printString value: (self at: i))].
	^ aDictionary