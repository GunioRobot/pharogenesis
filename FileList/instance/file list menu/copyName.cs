copyName

	listIndex = 0 ifTrue: [^ self].
	ParagraphEditor clipboardTextPut: self fullName asText.
