dispatchOnCharacter: char with: typeAheadStream
	"Check for Enter and cause an DOIT"
	| print |
	^ char = Character enter
		ifTrue: [self dispatchOnEnterWith: typeAheadStream]
		ifFalse: [super dispatchOnCharacter: char with: typeAheadStream]