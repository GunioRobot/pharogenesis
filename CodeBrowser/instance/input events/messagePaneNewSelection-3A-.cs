messagePaneNewSelection: arg1
	codePane scroller removeAllMorphs.
	arg1 ifNil: [^ self].
	codePane scroller addMorph:
		(TextMorph new contents:
			(self selectedClassOrMetaClass sourceMethodAt: arg1))