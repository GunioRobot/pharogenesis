accelerationSuspended
	"Return true if hardware acceleration is temporarily suspended"
	^self valueOfProperty: #accelerationSuspended ifAbsent:[false]