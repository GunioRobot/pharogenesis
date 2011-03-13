prettyPrint
	"Reformat the contents of the receiver's view (a Browser)."

	| selectedClass newText |
	model selectedMessageCategoryName ifNil: [^ self flash].
	selectedClass := model selectedClassOrMetaClass.
	newText := selectedClass prettyPrinterClass
		format: self text
		in: selectedClass
		notifying: self.
	newText ifNotNil:
		[self deselect; selectInvisiblyFrom: 1 to: paragraph text size.
		self replaceSelectionWith: (newText asText makeSelectorBoldIn: selectedClass).
		self selectAt: 1]