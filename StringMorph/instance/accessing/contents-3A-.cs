contents: newContents

	newContents isText
		ifTrue: [emphasis _ newContents emphasisAt: 1.
				contents _ newContents string]
		ifFalse: [contents = newContents ifTrue: [^ self].  "no substantive change"
				contents _ newContents].
	self fitContents.
	self changed

