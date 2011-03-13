versionsOfMethod: methodReference 
	| class selector |
	class := methodReference actualClass.
	selector := methodReference methodSymbol.
	^ self scan: SourceFiles from: (class compiledMethodAt: selector) sourcePointer