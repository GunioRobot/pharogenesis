dispatchOn: currentBytecode in: selectorArray
	"Simulate a case statement via selector table lookup. The given integer must be between 0 and (selectorArray size - 1), inclusive. Send the selector at (currentBytecode + 1) in selectorArray to the receiver. For speed, no extra range test is done, since it is done by the at: operation."
	"Note: Delete this method from the generated code."

	"assert: (currentBytecode >= 0) | (currentBytecode < selectorArray size)"
	self perform: (selectorArray at: (currentBytecode + 1)).