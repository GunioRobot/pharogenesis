initializePanels
	"initialize the receiver's panels"
	translationsList := PluggableListMorphOfMany
				on: self
				list: #translations
				primarySelection: #selectedTranslation
				changePrimarySelection: #selectedTranslation:
				listSelection: #selectedTranslationsAt:
				changeListSelection: #selectedTranslationsAt:put:
				menu: #translationsMenu:
				keystroke: #translationsKeystroke:.
	translationsList setBalloonText: 'List of all the translated phrases.' translated.
	""
	untranslatedList := PluggableListMorph
				on: self
				list: #untranslated
				selected: #selectedUntranslated
				changeSelected: #selectedUntranslated:
				menu: #untranslatedMenu:
				keystroke: #untranslatedKeystroke:.
	untranslatedList setBalloonText: 'List of all the untranslated phrases.' translated.
	""
	translationText := PluggableTextMorph
				on: self
				text: #translation
				accept: #translation:
				readSelection: nil
				menu: nil.
	translationText setBalloonText: 'Translation for the selected phrase in the upper list.' translated.
	""
	self
		addMorph: translationsList
		frame: (0 @ 0.18 corner: 0.5 @ 0.66).
	self
		addMorph: untranslatedList
		frame: (0.5 @ 0.18 corner: 1 @ 0.93).
	self
		addMorph: translationText
		frame: (0 @ 0.66 corner: 0.5 @ 0.93)