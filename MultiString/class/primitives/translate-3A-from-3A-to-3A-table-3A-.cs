translate: aString from: start  to: stop  table: table
	"translate the characters in the string by the given table, in place"

	| char |
	self var: #table  declareC: 'unsigned char *table'.
	self var: #aString  declareC: 'unsigned int *aString'.

	start to: stop do: [:i |
		char _ aString basicAt: i.
		char < 256 ifTrue: [
			aString basicAt: i put: (table at: char+1) asciiValue
		].
	].
