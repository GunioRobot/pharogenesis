subclassesDo: aBlock
	"Evaluate aBlock for each of the receiver's immediate subclasses."
	self == Class class
		ifTrue: ["Don't include Object class class in Class class's subclasses (heh heh)"
				thisClass subclassesDo: [:aSubclass | aSubclass == Object class
											ifFalse: [aBlock value: aSubclass class]]]
		ifFalse: [thisClass == nil
				ifFalse: [thisClass subclassesDo: [:aSubclass | aBlock value: aSubclass class]]]