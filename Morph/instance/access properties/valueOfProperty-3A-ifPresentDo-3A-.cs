valueOfProperty: propName ifPresentDo: aBlock
	"If the receiver has a property of the given name, evaluate aBlock on behalf of the value of that property"

	extension == nil ifTrue: [^ self].
	^ aBlock value: (extension valueOfProperty: propName ifAbsent: [^ self])