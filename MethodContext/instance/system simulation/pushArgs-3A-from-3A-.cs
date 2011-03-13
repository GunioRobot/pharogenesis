pushArgs: args "<Array>" from: sendr "<ContextPart>" 
	"Helps simulate action of the value primitive for closures.
	 This is used by ContextPart>>runSimulated:contextAtEachStep:"

	stackp ~= 0 ifTrue:
		[self error: 'stack pointer should be zero!'].
	closureOrNil ifNil:
		[self error: 'context needs a closure!'].
	args do: [:arg| self push: arg].
	1 to: closureOrNil numCopiedValues do:
		[:i|
		self push: (closureOrNil copiedValueAt: i)].
	sender := sendr