copyMethodDictionaryFrom: donorClass
	"Copy the method dictionary of the donor class over to the receiver"

	methodDict _ donorClass copyOfMethodDictionary.
	organization _ donorClass organization deepCopy