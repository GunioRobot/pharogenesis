hasTableLayoutString
	| layout |
	^((layout _ self layoutPolicy) notNil and:[layout isTableLayout])
		ifTrue:['<on>table layout']
		ifFalse:['<off>table layout'].