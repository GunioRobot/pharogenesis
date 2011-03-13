methodReferences
	^ (self theClass organization listAtCategoryNamed: name)
		collect: [:ea | MethodReference new
						setClassSymbol: self theNonMetaClassName
						classIsMeta: self theClass isMeta
						methodSymbol: ea
						stringVersion: '']
