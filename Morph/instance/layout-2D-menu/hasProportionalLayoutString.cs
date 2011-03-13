hasProportionalLayoutString
	| layout |
	^((layout _ self layoutPolicy) notNil and:[layout isProportionalLayout])
		ifTrue:['<on>proportional layout']
		ifFalse:['<off>proportional layout'].