dependenciesForClass: aClass 
	| r |
	r := Set new.
	aClass methodDict values
		do: [:cm | (cm literals
				select: [:l | l isKindOf: LookupKey]) 
				do: [:ll | ll key
						ifNotNil: [r add: ll key]]].
	^ r