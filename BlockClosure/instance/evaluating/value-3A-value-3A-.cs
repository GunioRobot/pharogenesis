value: arg1 value: arg2
	"Evaluate the block with the given args. Fail if the block expects other than 2 arguments."

	^ environment with: arg1 with: arg2 executeMethod: method