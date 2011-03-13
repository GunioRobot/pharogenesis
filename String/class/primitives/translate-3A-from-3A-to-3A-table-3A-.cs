translate: aString from: start  to: stop  table: table
	"Trivial, non-primitive version"
	| char |
	start to: stop do: [:i |
		char _ (aString at: i) asInteger.
		char < 256 ifTrue: [aString at: i put: (table at: char+1)].
	].
