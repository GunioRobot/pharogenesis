testAllMethodsSelect
	"self run: #testAllMethodsSelect"
	| res |
	res _ SystemNavigation new
				allMethodsSelect: [:each | each messages includes: #zoulouSymbol].
	self assert: res size = 1.
	self assert: (res at: 1) methodSymbol = #callingAThirdMethod