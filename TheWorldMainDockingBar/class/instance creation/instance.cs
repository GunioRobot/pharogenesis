instance
	"Answer the receiver's instance"
	^ Instance
		ifNil: [Instance := super new]