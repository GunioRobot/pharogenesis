compileInstVarAccessorsFor: varName
	| nameString |

	nameString _ varName asString capitalized.
	self class compile: ('get', nameString, '
	^ ', varName)
		classified: 'access' notifying: nil.

	self class compile: ('set', nameString, ': val
	', varName, ' _ val')
		classified: 'access' notifying: nil.