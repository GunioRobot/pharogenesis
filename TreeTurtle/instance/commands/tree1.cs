tree1
	"Draw a recursive tree whose trunk length is determined by my depth instance variable. Stop when depth is < 1."

	depth < 1 ifTrue: [^ self stop].
	depth _ depth - 1.
	self forward: 2 * depth.
	self turnRight: 20.
	self replicate.				"create child 1"
	self turnLeft: 40.
	self replicate.				"create child 2"
	self die.						"this turtle dies"
