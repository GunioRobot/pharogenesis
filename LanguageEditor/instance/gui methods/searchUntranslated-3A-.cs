searchUntranslated: aString 
	| untranslateds results index |
	untranslateds := self untranslated.
	results := untranslateds
				select: [:each | '*' , aString , '*' match: each].
	""
	results isEmpty
		ifTrue: [""
			self inform: 'no matches for' translated , ' ''' , aString , ''''.
			^ self].
	""
	results size = 1
		ifTrue: [""
			self selectUntranslatedPhrase: results first.
			^ self].
	""
	index := (UIManager default 
				chooseFrom: (results
						collect: [:each | each copy replaceAll: Character cr with: $\])
				title: 'select the untranslated phrase...' translated).
	""
	index isZero
		ifTrue: [""
			self beep.
			^ self].
	""
	self
		selectUntranslatedPhrase: (results at: index)