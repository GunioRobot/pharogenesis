browseMethodsWithTranslation
	| translation |
	self selectedTranslation isZero
		ifTrue: [""
			self beep.
			self inform: 'select the translation to look for' translated.
			^ self].
	""
	translation := self translations at: self selectedTranslation.
	self systemNavigation browseMethodsWithLiteral: translation