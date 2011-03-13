namedTileScriptSelectors
	scripts ifNil: [^ OrderedCollection new].
	^ scripts select: [:aScript | (aScript isAnonymous not) & (aScript selector ~~ nil)] 
		thenCollect: [:aScript | aScript selector]