removeTranslation
	"remove the selected translation"
	| translation |
	self selectedTranslation isZero
		ifTrue: [""
			self beep.
			self inform: 'select the translation to remove' translated.
			^ self].
	""
	translation := self translations at: self selectedTranslation.
""
	(self
			confirm: ('Removing "{1}".
Are you sure you want to do this?' translated format: {translation}))
		ifFalse: [^ self].
""
	self translator removeTranslationFor: translation.
	self changed: #translations.
	self changed: #untranslated.