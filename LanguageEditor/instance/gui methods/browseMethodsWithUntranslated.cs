browseMethodsWithUntranslated
	| untranslated |
	self selectedUntranslated isZero
		ifTrue: [""
			self beep.
			self inform: 'select the untranslated phrase to look for' translated.
			^ self].
	""
	untranslated := self untranslated at: self selectedUntranslated.
	SystemNavigation default browseMethodsWithLiteral: untranslated.
