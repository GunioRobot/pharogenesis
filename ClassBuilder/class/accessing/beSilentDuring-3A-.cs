beSilentDuring: aBlock
	"Temporarily suppress information about what is going on"
	| wasSilent result |
	wasSilent _ self isSilent.
	self beSilent: true.
	result _ aBlock value.
	self beSilent: wasSilent.
	^result