resourceDirectory
	resourceDirectory ifNil: [resourceDirectory _ self baseUrl copyFrom: 1 to: (self baseUrl lastIndexOf: $/)].
	^resourceDirectory