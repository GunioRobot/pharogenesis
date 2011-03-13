testRevertOldMethod
	| definition changeRecord |
	Object compile: 'yourself ^ self' classified: MCMockPackageInfo new methodCategoryPrefix.
	definition := (MethodReference class: Object selector: #yourself) asMethodDefinition.
	changeRecord := definition scanForPreviousVersion.
	self assert: changeRecord notNil.
	self assert: changeRecord category = 'accessing'.
	changeRecord fileIn.