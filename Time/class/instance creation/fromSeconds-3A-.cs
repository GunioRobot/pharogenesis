fromSeconds: secondCount 
	"Answer an instance of me that is secondCount number of seconds since midnight."

	^self new 
		setSeconds: secondCount;
		yourself.