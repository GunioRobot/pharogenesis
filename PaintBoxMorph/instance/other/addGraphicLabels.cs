addGraphicLabels
	"translate button labels"

	| formTranslator ext pos newForm |
	formTranslator _ NaturalLanguageFormTranslator localeID: (Locale current localeID).

	#('KEEP' 'UNDO' 'CLEAR' 'TOSS') do: [:label |
		(formTranslator translate: label, '-off') ifNil: [^ false].
		(formTranslator translate: label, '-pressed') ifNil: [^ false].
	].
	
	#('keep:' 'undo:' 'clear:' 'toss:') with: #('KEEP' 'UNDO' 'CLEAR' 'TOSS') do: [:extName :label |
		| button |
		button _ submorphs detect: [:m | m externalName = extName] ifNone: [nil].
		button ifNotNil: [
			button removeAllMorphs.
			ext _ button extent.
			pos _ button position.
			(newForm _ formTranslator translate: label, '-off') ifNotNil: [
				button offImage: newForm.

			].
			(newForm _ formTranslator translate: label, '-pressed') ifNotNil: [
				button pressedImage: newForm.
			].
			button extent: ext.
			button position: pos.
		].
	].

	^ true.
