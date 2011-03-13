delete
	model isMorphicModel
		ifFalse: [^ super delete].
	slotName
		ifNotNil: [(self confirm: 'Shall I remove the slot "' translated , slotName , '"\along with all associated methods?' withCRs translated)
				ifTrue: [(model class selectors
						select: [:s | s beginsWith: slotName])
						do: [:s | model class removeSelector: s].
					(model class instVarNames includes: slotName)
						ifTrue: [model class removeInstVarName: slotName]] 
				ifFalse: [(self confirm: '...but should I at least dismiss this morph?' translated , ('\' , 'Choose "No" to leave everything unchanged' translated) withCRs)
						ifFalse: [^ self]]].
	super delete