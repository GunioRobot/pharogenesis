valueWithArguments: anArray 
	"Evaluate the block with given args. Fail if the block expects other than the given number of arguments."

	^ environment withArgs: anArray executeMethod: method