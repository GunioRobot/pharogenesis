storeInteger: fieldIndex ofObject: objectPointer withValue: integerValue
	"Note: May be called by translated primitive code."

	(self isIntegerValue: integerValue) ifTrue: [
		self storeWord: fieldIndex
			ofObject: objectPointer
			withValue: (self integerObjectOf: integerValue).
	] ifFalse: [
		self primitiveFail
	].