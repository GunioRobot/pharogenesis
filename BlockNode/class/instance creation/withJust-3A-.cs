withJust: aNode
	"Used to create a simple block, eg: withJust: NodeNil"
	^ self new statements: (Array with: aNode) returns: false