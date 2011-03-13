prettyPrint: decorated
	"Reformat the contents of the receiver's view (a Browser)."

	| selectedClass newText |
	model selectedMessageCategoryName ifNil: [^ view flash].
	selectedClass _ model selectedClassOrMetaClass.
	newText _ selectedClass prettyPrinterClass
		format: self text
		in: selectedClass
		notifying: self
		decorated: decorated.
	newText ifNotNil:
		[self deselect; selectInvisiblyFrom: 1 to: paragraph text size.
		self replaceSelectionWith: (newText asText makeSelectorBoldIn: selectedClass).
		self selectAt: 1]