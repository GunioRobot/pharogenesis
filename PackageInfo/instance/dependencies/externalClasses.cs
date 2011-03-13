externalClasses
	| myClasses |
	myClasses := self classesAndMetaClasses asSet.
	^ Array streamContents:
		[:s |
		ProtoObject withAllSubclassesDo:
			[:class |
			(myClasses includes: class) ifFalse: [s nextPut: class]]]