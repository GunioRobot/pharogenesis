appendEntry
	"Append the text in the model's writeStream to the editable text. "
	
	view topView isCollapsed
		ifTrue: [paragraph text
				replaceFrom: 1
				to: paragraph text size
				with: model contents asText]
		ifFalse: 
			[self deselect.
			paragraph text size > model characterLimit ifTrue: 
				[paragraph removeFirstChars: paragraph text size - (model characterLimit // 2)].
			self selectWithoutComp: paragraph text size + 1.
			self replaceSelectionWith: model nextEntry asText.
			self selectWithoutComp: paragraph text size + 1.
			model contents: paragraph text]