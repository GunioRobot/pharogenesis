asIRCLowercase
	"convert to lowercase, using IRC's rules"

	self == $[ ifTrue: [ ^ ${ ].
	self == $] ifTrue: [ ^ $} ].
	self == $\ ifTrue: [ ^ $| ].

	^self asLowercase