updateAcceptButton

	self model canAccept
		ifTrue:
			[acceptButtonView
				backgroundColor: Color green;
				borderWidth: 3;
				controller: acceptButtonView defaultController]
		ifFalse:
			[acceptButtonView
				backgroundColor: Color lightYellow;
				borderWidth: 1;
				controller: NoController new].
	acceptButtonView display.