untranslatedFilterWording
	^ self untranslatedFilter isEmpty
		ifTrue: ['filter' translated]
		ifFalse: ['filtering: {1}' translated format: {self untranslatedFilter}]