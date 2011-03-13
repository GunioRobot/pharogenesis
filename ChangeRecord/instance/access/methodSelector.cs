methodSelector
	type == #method ifFalse: [^ nil].
	^ Parser new parseSelector: self string