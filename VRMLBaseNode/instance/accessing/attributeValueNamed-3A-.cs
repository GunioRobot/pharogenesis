attributeValueNamed: aString
	"Return the value of the given attribute string as defined in the receiver.
	Note: When switching to a full class representation for VRML objects we can
	get rid of this and use actual accessors."
	| attr |
	attr _ (self attributeNamed: aString) ifNil:[^nil].
	^self getAttributeValue: attr