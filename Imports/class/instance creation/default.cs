default
	"Answer my default instance, creating one if necessary."
	"Imports default"
	^default ifNil: [ default _ self new ]