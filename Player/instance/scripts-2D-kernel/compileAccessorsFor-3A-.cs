compileAccessorsFor: varName
	^ self compileInstVarAccessorsFor: varName


	"code below is the implementation where we use a slots dictionary rather than true inst vars

	nameString _ varName asString capitalized.

	self class compile: ('get', nameString, '
	^ self atSlot: #', varName)
		classified: 'access' notifying: nil.

	self class compile: ('set', nameString, ': val
		self atSlot: #', varName, ' put: val')
		classified: 'access' notifying: nil"