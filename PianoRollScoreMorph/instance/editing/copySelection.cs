copySelection

	selection == nil ifTrue: [^ self].
	NotePasteBuffer _ (score tracks at: selection first)
		copyFrom: selection second to: selection third