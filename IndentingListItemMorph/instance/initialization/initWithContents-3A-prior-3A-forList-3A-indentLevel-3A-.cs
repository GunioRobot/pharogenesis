initWithContents: anObject prior: priorMorph forList: hostList indentLevel: newLevel

	container _ hostList.
	complexContents _ anObject.
	self initWithContents: anObject asString font: Preferences standardListFont emphasis: nil.
	indentLevel _ 0.
	isExpanded _ false.
 	nextSibling _ firstChild _ nil.
	priorMorph ifNotNil: [
		priorMorph nextSibling: self.
	].
	indentLevel _ newLevel.
