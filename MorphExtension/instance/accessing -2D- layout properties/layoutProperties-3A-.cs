layoutProperties: newProperties 
	"Return the current layout properties associated with the receiver"

	newProperties 
		ifNil: [self removeProperty: #layoutProperties]
		ifNotNil: [self setProperty: #layoutProperties toValue: newProperties]