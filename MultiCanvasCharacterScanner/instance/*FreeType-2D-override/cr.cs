cr
	"When a carriage return is encountered, simply increment the pointer 
	into the paragraph."

	pendingKernX := 0.
	lastIndex:= lastIndex + 1.
	^false