testAllMethodsInCategory
	"This is a non regression test for http://bugs.squeak.org/view.php?id=6986
	allMethodsInCategory: should return a list of existing methods"
	
	| classAndMethods methodReferences |
	classAndMethods := SystemNavigation default allMethodsInCategory: 'removing'.
	methodReferences := classAndMethods collect: [:e | e isString
		ifTrue: [MessageSet 
			parse: e
			toClassAndSelector: [:cls :sel | MethodReference class: cls selector: sel]]
		ifFalse: [e]].
	self assert: (methodReferences allSatisfy: [:mr | mr actualClass includesSelector: mr methodSymbol])