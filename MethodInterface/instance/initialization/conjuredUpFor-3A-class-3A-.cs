conjuredUpFor: aSelector class: aClass
	"Initialize the receiver to have the given selector, obtaining whatever info one can from aClass.  This basically covers the situation where no formal definition has been made."

	| parts |
	self initializeFor: aSelector.
	self wording: aSelector.

	receiverType _ #unknown.
	parts _ aClass formalHeaderPartsFor: aSelector.
	argumentVariables _ (1 to: selector numArgs) collect:
		[:anIndex | Variable new name: (parts at: (4 * anIndex)) type: #Object].
	parts last isEmptyOrNil ifFalse: [self documentation: parts last].
