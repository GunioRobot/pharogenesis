playSoundNamed: aString
	"SampledSound playSoundNamed: 'croak'"
	| aSound |
	(aSound _ self soundNamed: aString) ifNotNil: [aSound play]