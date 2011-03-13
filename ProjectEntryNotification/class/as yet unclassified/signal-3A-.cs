signal: aProject

	| ex |
	ex := self new.
	ex initialContext: thisContext sender.
	ex projectToEnter: aProject.
	^ex signal: 'Entering ',aProject printString