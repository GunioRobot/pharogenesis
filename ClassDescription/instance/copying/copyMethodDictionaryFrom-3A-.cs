copyMethodDictionaryFrom: donorClass
	"Copy the method dictionary of the donor class over to the receiver"

	methodDict _ donorClass copyOfMethodDictionary.
	self organization: donorClass organization deepCopy.