description: aText

	self selectedRepository ifNotNilDo: [:repo | 
		| new | 
		new := MCRepository readFrom: aText asString.
		(new class = repo class 
			and: [new description = repo description])
				ifTrue: [
					repo creationTemplate: aText asString.
					self changed: #description]
				ifFalse: [
					self inform: 'This does not match the previous definition!'
				]
	].

