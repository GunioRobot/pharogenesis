contents
	| objects |
	objects := Utilities pointersTo: item except: (Array with: self with: model).	
	^(objects reject: [:ea | ea class = self class])
		collect: [:ea| self class with: ea name: ea identityHash asString model: item]