accelerationEnabled
	"Return true if hardware acceleration is enabled"
	self accelerationSuspended ifTrue:[^false].
	^self valueOfProperty: #accelerationEnabled ifAbsent:[false]