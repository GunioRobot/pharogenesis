copyName

	listIndex = 0 ifTrue: [^ self].
	ParagraphEditor new clipboardTextPut: self fullName asText.
