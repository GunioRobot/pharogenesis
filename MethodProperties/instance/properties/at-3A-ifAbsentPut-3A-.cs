at: aKey ifAbsentPut: aBlock
	"Answer the property associated with aKey or, if aKey isn't found store the result of evaluating aBlock as new value."
	
	^ self at: aKey ifAbsent: [ self at: aKey put: aBlock value ].