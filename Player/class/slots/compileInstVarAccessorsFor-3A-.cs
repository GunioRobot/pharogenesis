compileInstVarAccessorsFor: varName
	| nameString |

	nameString _ varName asString capitalized.
	self compileUnlogged: ('get', nameString, '
	^ ', varName)
		classified: 'access' notifying: nil.
	self compileUnlogged: ('set', nameString, ': val
	', varName, ' _ val')
		classified: 'access' notifying: nil