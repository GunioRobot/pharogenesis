redButtonActivity
	model okToChange  "Dont change selection if model is locked"
		ifTrue: [^ super redButtonActivity]