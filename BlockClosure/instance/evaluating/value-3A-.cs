value: arg1
	"Evaluate the block with the given args. Fail if the block expects other than 1 arguments."

	^ environment with: arg1 executeMethod: method