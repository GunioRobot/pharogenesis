setupFromParameters
	(self includesParameter: 'showSplash')
		ifTrue: [showSplash _ (self parameterAt: 'showSplash') asUppercase = 'TRUE'].
	(self includesParameter: 'flaps')
		ifTrue: [whichFlaps _ (self parameterAt: 'flaps')].
