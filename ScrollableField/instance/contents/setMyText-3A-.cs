setMyText: someText
	"Set my text, as indicated"

	| toUse |
	toUse _ someText ifNil: [''].
	myContents _ toUse.
	self setText: toUse.
	^ true