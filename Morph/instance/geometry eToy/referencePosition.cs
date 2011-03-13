referencePosition
	"Return the current reference position of the receiver"
	| box |
	box _ self bounds.
	^box origin + (self rotationCenter * box extent).
