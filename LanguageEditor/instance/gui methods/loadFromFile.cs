loadFromFile
	| fileName |
	fileName := self selectTranslationFileName.
	fileName isNil
		ifTrue: [""
			self beep.
			^ self].
	""
	Cursor wait
		showWhile: [
			self translator loadFromFileNamed: fileName.
			self changed: #translations.
			self changed: #untranslated]