removeUntranslated
	"remove the selected untranslated phrase"
	| untranslated |
	self selectedUntranslated isZero
		ifTrue: [""
			self beep.
			self inform: 'select the untranslated phrase to remove' translated.
			^ self].
	""
	untranslated := self untranslated at: self selectedUntranslated.
	""
	(self
			confirm: ('Removing "{1}".
Are you sure you want to do this?' translated format: {untranslated}))
		ifFalse: [^ self].
	""
	self translator removeUntranslated: untranslated