hasUnacceptedEdits: aBoolean
	super hasUnacceptedEdits: aBoolean.
	(aBoolean and:[self okToStyle])
		ifTrue: [ styler styleInBackgroundProcess: displayContents text]