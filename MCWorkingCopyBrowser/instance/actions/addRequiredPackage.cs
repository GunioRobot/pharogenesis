addRequiredPackage
	| chosen |
	workingCopy ifNotNilDo:
		[:wc |
		chosen := self pickWorkingCopySatisfying: 
			[:ea | ea ~= wc and: [(wc requiredPackages includes: ea package) not]].
		chosen ifNotNil:
			[wc requirePackage: chosen package.
			self workingCopyListChanged]]