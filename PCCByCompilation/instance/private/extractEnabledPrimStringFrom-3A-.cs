extractEnabledPrimStringFrom: aSourceString 
	| startString start stop |
	startString := self enabledPrimStartString.
	start := aSourceString findString: startString.
	start = 0
		ifTrue: [^ nil].
	stop := aSourceString indexOf: self enabledPrimStopChar startingAt: start + startString size.
	stop = 0
		ifTrue: [^ nil].
	^ {aSourceString copyFrom: start to: stop. start}