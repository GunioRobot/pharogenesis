isDoing
	"Call from a doer/undoer/redoer any time to see which it is."

	^(self isUndoing | self isRedoing) not