searchTranslation: aString 
	| translations results index |
	translations := self translations.
	results := translations
				select: [:each | ""
					('*' , aString , '*' match: each)
						or: ['*' , aString , '*' match: (self translator translationFor: each)]].
	""
	results isEmpty
		ifTrue: [""
			self inform: 'no matches for' translated , ' ''' , aString , ''''.
			^ self].
	""
	results size = 1
		ifTrue: [""
			self selectTranslationPhrase: results first.
			^ self].
	""
	index := (PopUpMenu
				labelArray: (results
						collect: [:each | ""
							(each copy replaceAll: Character cr with: $\)
								, ' -> '
								, ((self translator translationFor: each) copy replaceAll: Character cr with: $\)]))
				startUpWithCaption: 'select the translation...' translated.
	""
	index isZero
		ifTrue: [""
			self beep.
			^ self].
	""
	self
		selectTranslationPhrase: (results at: index)