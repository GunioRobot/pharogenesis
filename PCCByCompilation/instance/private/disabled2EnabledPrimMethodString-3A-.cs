disabled2EnabledPrimMethodString: aSourceString 
	| start stop primString extract |
	extract := self extractDisabledPrimStringFrom: aSourceString.
	primString := extract at: 1.
	start := extract at: 2.
	stop := start + primString size - 1.
	^ aSourceString
		copyReplaceFrom: start
		to: stop
		with: (self disabled2EnabledPrimString: primString)