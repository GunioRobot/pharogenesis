numberOfMethods
	"cound all methods that are local (not comming from a trait)"
	| num |
	num := (methodDict values select: [:each | self includesLocalSelector: each selector]) size.
	self isMeta 
		ifTrue: [^ num] 
		ifFalse: [^ num + self class numberOfMethods]