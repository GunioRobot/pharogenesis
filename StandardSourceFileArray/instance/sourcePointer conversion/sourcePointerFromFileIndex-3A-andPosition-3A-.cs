sourcePointerFromFileIndex: index andPosition: position
	| hi lo |
	"Return a source pointer according to the new 32M algorithm"
	((index between: 1 and: 2) and: [position between: 0 and: 16r1FFFFFF])
		ifFalse: [self error: 'invalid source code pointer'].
	hi _ index.
	lo _ position.
	lo >= 16r1000000 ifTrue: [
		hi _ hi+2.
		lo _ lo - 16r1000000].
	^hi * 16r1000000 + lo