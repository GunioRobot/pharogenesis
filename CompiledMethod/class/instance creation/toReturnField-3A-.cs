toReturnField: field 
	"Answer an instance of me that is a quick return of the instance variable 
	indexed by the argument, field."

	^ self newBytes: 0 nArgs: 0 nTemps: 0 nStack: 0 nLits: 0 primitive: 264 + field
