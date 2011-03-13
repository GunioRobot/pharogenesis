tileScriptNames
	scripts ifNil: [^ OrderedCollection new].
	^ scripts collect: [:aScript | aScript selector]