mouseoverString
	^ popOutOnMouseOver
		ifTrue:
			['cease popping out on mouseover']
		ifFalse:
			['start popping out on mouseover']