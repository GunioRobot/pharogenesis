clipSubmorphs
	"Drawing specific. If this property is set, clip the receiver's  
	submorphs to the receiver's clipping bounds."
	^ self
		valueOfProperty: #clipSubmorphs
		ifAbsent: [false]