initShapeDicts
	"Initialize me. "

	self flag: #bobconv.	

	"These must stay constant.  When structures read in, then things can change."
	steady _ {Array. Dictionary. Association. ByteString. SmallInteger} asSet.

	renamed ifNil: [
		renamed _ Dictionary new.  "(old class name symbol -> new class name)"
		renamedConv _ Dictionary new "(oldClassNameSymbol -> conversionSelectorInNewClass)"
	].
	self initKnownRenames