workingCopyListMenu: aMenu
	workingCopy ifNil: [^ aMenu].
	self fillMenu: aMenu fromSpecs:
		#(('add required package' #addRequiredPackage)
		   ('remove required package' #removeRequiredPackage)
			('add all dirty packages as required' #addRequiredDirtyPackage)
			('clear required packages' #clearRequiredPackages)
			('browse package' #browseWorkingCopy)
			('view changes' #viewChanges)
			('view history' #viewHistory)
			('recompile package' #recompilePackage)
			('revert package...' #revertPackage)
			('unload package' #unloadPackage)
			('delete working copy' #deleteWorkingCopy)).
	(Smalltalk includesKey: #SARMCPackageDumper) ifTrue: [
		aMenu add: 'make SAR' target: self selector: #fileOutAsSAR
	].
	aMenu addLine.
	1 to: self orderSpecs size do: [ :index |
		aMenu addUpdating: #orderString: target: self selector: #order: argumentList: { index } ].
	^aMenu