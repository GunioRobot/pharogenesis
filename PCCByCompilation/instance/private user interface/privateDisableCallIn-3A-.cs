privateDisableCallIn: aMethodRef 
	"Disables enabled or failed external prim call by recompiling method 
	with prim call commented out, will be called by superclass."
	| src newMethodSource |
	"higher priority to avoid source file accessing errors"
	[src := aMethodRef sourceString]
		valueAt: self higherPriority.
	newMethodSource := self enabled2DisabledPrimMethodString: src.
	"higher priority to avoid source file accessing errors"
	[aMethodRef actualClass
		compile: newMethodSource
		classified: (aMethodRef actualClass whichCategoryIncludesSelector: aMethodRef methodSymbol)
		notifying: nil]
		valueAt: self higherPriority