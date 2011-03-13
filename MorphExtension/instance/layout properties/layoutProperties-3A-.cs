layoutProperties: newProperties
	"Return the current layout properties associated with the receiver"
	newProperties == nil
		ifTrue:[self removeProperty: #layoutProperties]
		ifFalse:[self setProperty: #layoutProperties toValue: newProperties].