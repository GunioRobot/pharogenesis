collectVariables
	^messages inject: receiver collectVariables into: [:array :message | array, message collectVariables]