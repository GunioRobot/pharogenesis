collectVariables
	^arguments inject: receiver collectVariables into: [:array :argument | array, argument collectVariables]