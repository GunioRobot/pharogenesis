showBytecodes
	"Show the bytecodes of the selected method."

	| selectedClass newText |
	(model messageListIndex = 0) | (model isLocked) ifTrue: [
		^view flash.
	].

	selectedClass _ model selectedClassOrMetaClass.
	Cursor execute showWhile: [
		self deselect; selectInvisiblyFrom: 1 to: paragraph text size.
		newText _ (selectedClass compiledMethodAt: model selectedMessageName) symbolic asText.
		self replaceSelectionWith: newText.
		self selectAt: 1.
	].

	self unlockModel.