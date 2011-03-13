collectVariables
	^statements inject: Array new into: [:array :statement | array, statement collectVariables]