value: arg1 value: arg2 value: arg3
	"Evaluate the block with the given args. Fail if the block expects other than 3 arguments."

	^ environment with: arg1 with: arg2 with: arg3 executeMethod: method