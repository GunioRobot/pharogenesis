methodsCalledAndCalleeForClass: aClass 
	| r |
	r := Set new.
	aClass methodDict
		associationsDo: [:assoc | (assoc value literals
				select: [:l | l isSymbol])
				do: [:ll | r 
						add: (Array with: assoc key with: ll)]].
	^ r