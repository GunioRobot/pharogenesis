defaultPollPeriod
	"Answer the number of milliseconds between interrupts for spyOn: and friends.
	This should be faster for faster machines."
	^DefaultPollPeriod ifNil: [ DefaultPollPeriod _ 1 ]