translate: aString from: start  to: stop  table: table
	"translate the characters in the string by the given table, in place"
	<primitive: 243>
	self var: #table  declareC: 'unsigned char *table'.
	self var: #aString  declareC: 'unsigned char *aString'.

	start to: stop do: [ :i |
		aString at: i put: (table at: (aString at: i) asciiValue+1) ]