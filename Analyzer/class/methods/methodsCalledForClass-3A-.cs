methodsCalledForClass: aClass 
	| r |
	r := Set new.
	aClass methodDict values 
		do: [:cm | (cm literals
				select: [:l | l isKindOf: Symbol])
				do: [:ll | r add: ll]].
	^ r