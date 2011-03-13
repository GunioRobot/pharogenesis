at: aKey
	"Answer the property value associated with aKey."
	
	^ self at: aKey ifAbsent: [ self error: 'Property not found' ].