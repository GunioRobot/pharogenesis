initialize
	"self initialize"
	
	Transcript show: 'Initializing ObjectWithInitialize. classVar state was: ', ClassVar asString; cr.
	
	ClassVar isNil  
		ifTrue: [ClassVar := 1]
		ifFalse: [ClassVar := 2].
	Transcript show: 'After initializing ObjectWithInitialize. classVar state is: ', ClassVar asString; cr.