externalClasses
	| myClasses |
	myClasses _ self classesAndMetaClasses.
	^ Array streamContents:
		[:s |
		ProtoObject withAllSubclassesDo:
			[:class |
			(myClasses includes: class) ifFalse: [s nextPut: class]]]