balloonText
	^ ((mouseInside
			ifNil: [false])
		ifTrue: ['Click here to see FEWER buttons.']
		ifFalse: ['Click here to see MORE buttons.'])  translated