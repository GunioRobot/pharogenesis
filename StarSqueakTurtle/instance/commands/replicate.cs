replicate
	"Add an exact replica of this turtle to the world. The new turtle does not become active until the next cycle."
	"Note: We call this operation 'replicate' instead of Mitch Resnick's term 'clone' because Squeak already used the message 'clone' for cloning a generic object."

	world replicateTurtle: self.
