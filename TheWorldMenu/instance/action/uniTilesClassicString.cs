uniTilesClassicString
	^ ((myProject
			parameterAt: #uniTilesClassic
			ifAbsent: [false])
		ifTrue: ['<yes>']
		ifFalse: ['<no>']), 'classic tiles' translated