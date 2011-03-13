forSystem
	"return a configuration describing the currently running system"
	^SystemConfiguration ifNil: [ SystemConfiguration _ self new ].
	