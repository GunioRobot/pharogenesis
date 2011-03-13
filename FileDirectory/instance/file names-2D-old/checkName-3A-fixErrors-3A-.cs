checkName: aFileName fixErrors: fixing 
	"Check a string aFileName for validity as a file name. If there are 
	problems (e.g., illegal length or characters) and fixing is false, create 
	an error; if there are problems and fixing is true, make the name legal 
	(usually by truncating and/or tranforming characters) and answer the 
	new name. Otherwise, answer the name. Default behavior is to shorten
	to 31 chars. Subclasses can do any kind of checking they want and 
	answer either the name, or false if no good."

	aFileName isEmpty
		ifTrue: [self error: 'file name empty'].
	aFileName size > 31 ifTrue:
		[fixing ifTrue: [^ aFileName contractTo: 31]
				ifFalse: [self error: 'file name too long']].
	^ aFileName