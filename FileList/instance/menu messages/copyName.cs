copyName
	listIndex = 0 ifTrue: [^ self].
	ParagraphEditor new clipboardTextPut: 
		(FileDirectory default localNameFor: self fullName) asText