workingCopyListMenu: aMenu
	workingCopy ifNil: [^ aMenu].
	self fillMenu: aMenu fromSpecs:
		#(
		  ('add required package' #addRequiredPackage)
		  ('clear required packages' #clearRequiredPackages)
		  ('browse package' #browseWorkingCopy)
		  ('view changes' #viewChanges)
		  ('view history' #viewHistory)
		  ('unload package' #unloadPackage)
		  ('delete working copy' #deleteWorkingCopy)).
	(Smalltalk includesKey: #SARMCPackageDumper) ifTrue: [
		aMenu add: 'make SAR' target: self selector: #fileOutAsSAR
	].
	^aMenu