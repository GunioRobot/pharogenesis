addNew: aString byEvaluating: aBlock
	"A parameterization of earlier versions of #addNewDirectory and
	#addNewFile.  Fixes the bug in each that pushing the cancel button
	in the FillInTheBlank dialog gave a walkback."

	| response newName index ending |
	self okToChange ifFalse: [^ self].
	(response _ FillInTheBlank request: 'New ',aString,' Name?'
 					initialAnswer: aString,'Name')
		isEmpty ifTrue: [^ self].
	newName _ response asFileName.
	Cursor wait showWhile: [
		aBlock value: newName].
	self updateFileList.
	index _ list indexOf: newName.
	index = 0 ifTrue: [ending _ ') ',newName.
		index _ list findFirst: [:line | line endsWith: ending]].
	self fileListIndex: index.
	newFiles add: newName
