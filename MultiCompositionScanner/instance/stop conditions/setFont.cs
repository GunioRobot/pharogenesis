setFont
	super setFont.
	breakAtSpace _ false.
	wantsColumnBreaks == true ifTrue: [
		stopConditions _ stopConditions copy.
		stopConditions at: TextComposer characterForColumnBreak asciiValue + 1 put: #columnBreak.
	].
