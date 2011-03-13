compileInitMethods
	| s nodeDict varNames |
	nodeDict _ IdentityDictionary new.
	s _ WriteStream on: (String new: 2000).
	varNames _ self class allInstVarNames.
	s nextPutAll: 'initMorph'.
	3 to: self class instSize do:
		[:i | (self instVarAt: i) isMorph ifTrue:
			[s cr; tab; nextPutAll: (varNames at: i) , ' _ '.
			s nextPutAll: (self instVarAt: i) initString; nextPutAll: '.'.
			nodeDict at: (self instVarAt: i) put: (varNames at: i)]].
	submorphs do: 
		[:m | s cr; tab; nextPutAll: 'self addMorph: '.
		m printConstructorOn: s indent: 1 nodeDict: nodeDict.
		s nextPutAll: '.'].
	self class
		compile: s contents
		classified: 'initialization'
		notifying: nil.