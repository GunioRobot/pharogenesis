bindArg: name 
	"Declare an argument."
	| node |
	nTemps >= 15
		ifTrue: [^self notify: 'Too many arguments'].
	node _ self bindTemp: name.
	^ node nowHasDef nowHasRef