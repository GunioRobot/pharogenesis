resultType
	"Answer the result type the receiver would produce."

	^ player typeForSlotWithGetter: (Utilities getterSelectorFor: variableName)