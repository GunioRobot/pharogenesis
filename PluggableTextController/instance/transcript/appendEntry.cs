appendEntry
	"Append the text in the model's writeStream to the editable text. "
	self deselect.
	paragraph text size > model characterLimit ifTrue:
		["Knock off first half of text"
		self selectInvisiblyFrom: 1 to: paragraph text size // 2.
		self replaceSelectionWith: Text new].
	self selectInvisiblyFrom: paragraph text size + 1 to: paragraph text size.
	self replaceSelectionWith: model contents asText.
	self selectInvisiblyFrom: paragraph text size + 1 to: paragraph text size