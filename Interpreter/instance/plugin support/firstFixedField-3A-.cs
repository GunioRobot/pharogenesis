firstFixedField: oop
	self returnTypeC:'void *'.
	^self cCoerce: oop+4 to:'void *'.