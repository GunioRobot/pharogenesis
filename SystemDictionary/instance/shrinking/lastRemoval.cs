lastRemoval  "Smalltalk lastRemoval"
	#(abandonSources printSpaceAnalysis cleanOutUndeclared browseObsoleteReferences obsoleteClasses lastRemoval) do:
		[:sel | SystemDictionary removeSelector: sel].
	[self removeAllUnSentMessages > 0] whileTrue