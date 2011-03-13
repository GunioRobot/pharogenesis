redButtonActivity
	model okToChange   "Don't change selection if model refuses to unlock"
		ifTrue: [^ super redButtonActivity]