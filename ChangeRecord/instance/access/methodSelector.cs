methodSelector
	type == #method
		ifFalse: [^ nil].
	^ self class parserClass new parseSelector: self string