copyExtension
	"Copy my extensions dictionary"
	| copiedExtension |
	self hasExtension
		ifFalse: [^ self].
	copiedExtension _ self extension copy.
	copiedExtension removeOtherProperties.
	self extension otherProperties
		ifNotNil: [self extension otherProperties
				associationsDo: [:assoc | copiedExtension setProperty: assoc key toValue: assoc value copy]].
	self privateExtension: copiedExtension