privateEnableCallIn: aMethodRef 
	"Enables disabled external prim call by recompiling method with prim  
	call taken from disabling comment, will be called by superclass."
	| src newMethodSource |
	"higher priority to avoid source file accessing errors"
	[src := aMethodRef sourceString]
		valueAt: self higherPriority.
	newMethodSource := self disabled2EnabledPrimMethodString: src.
	"higher priority to avoid source file accessing errors"
	[aMethodRef actualClass
		compile: newMethodSource
		classified: (aMethodRef actualClass whichCategoryIncludesSelector: aMethodRef methodSymbol)
		notifying: nil]
		valueAt: self higherPriority