currentItemSelection
	"Return the value of currentItemSelection"
	currentItemSelection ifNil: [^ 1 to: 0].
	^ currentItemSelection