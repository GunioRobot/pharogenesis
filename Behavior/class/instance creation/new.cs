new
	
	| classInstance |
	classInstance := self basicNew.
	classInstance methodDictionary: classInstance emptyMethodDictionary.
	classInstance superclass: Object.
	classInstance setFormat: Object format.
	^ classInstance