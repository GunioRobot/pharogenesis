newAccountWithId: anIdString 
	"Create an account and add it to me.
	Clear the accounts & users cache."

	accounts _ users _ nil.
	^self newObject: (SMAccount newIn: self withId: anIdString)