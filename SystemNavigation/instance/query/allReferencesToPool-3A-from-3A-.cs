allReferencesToPool: aPool from: aClass
	"Answer all the references to variables from aPool"
	| ref list |
	list := OrderedCollection new.
	aClass withAllSubclassesDo:[:cls|
		cls selectorsAndMethodsDo:[:sel :meth|
			ref := meth literals detect:[:lit|
				lit isVariableBinding and:[(aPool bindingOf: lit key) notNil]
			] ifNone:[nil].
			ref ifNotNil:[
				list add:(MethodReference new setStandardClass: cls methodSymbol: sel)
			].
		].
	].
	^list