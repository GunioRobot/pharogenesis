selfSentSelectorsFromSelectors: interestingSelectors 
	| m result info |
	result := IdentitySet new.
	interestingSelectors collect: 
			[:sel | 
			m := self compiledMethodAt: sel ifAbsent: [].
			m ifNotNil: 
					[info := (SendInfo on: m) collectSends.
					info selfSentSelectors do: [:sentSelector | result add: sentSelector]]].
	^result