enabled2DisabledPrimMethodString: aSourceString 
	| start stop primString extract |
	extract := self extractEnabledPrimStringFrom: aSourceString.
	primString := extract at: 1.
	start := extract at: 2.
	stop := start + primString size - 1.
	^ aSourceString
		copyReplaceFrom: start
		to: stop
		with: (self enabled2DisabledPrimString: primString)