removeNonLocalSelector: aSymbol
	| traits isAlias |
	traits _ self selectedClassOrMetaClass traitsProvidingSelector: aSymbol.
	isAlias _ self selectedClassOrMetaClass isLocalAliasSelector: aSymbol.
	isAlias
		ifTrue: [
			self assert: traits size = 1.
			self selectedClassOrMetaClass removeAlias: aSymbol of: traits first]
		ifFalse: [
			traits do: [:each |
				self selectedClassOrMetaClass addExclusionOf: aSymbol to: each ]]
	