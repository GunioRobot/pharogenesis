acceptMethod: methodSel dstMessageCategory: dstMessageCategorySel srcMessageCategory: srcMessageCategorySel dstClass: dstClass dstClassOrMeta: dstClassOrMeta srcClassOrMeta: srcClassOrMeta internal: internal copySemantic: copyFlag 
	| success hierarchyChange higher checkForOverwrite |
	(success _ dstClassOrMeta ~~ nil) ifFalse: [^false].
	checkForOverwrite _ dstClassOrMeta selectors includes: methodSel.
	hierarchyChange _ (higher _ srcClassOrMeta inheritsFrom: dstClassOrMeta) | (dstClassOrMeta inheritsFrom: srcClassOrMeta).
	success _ (checkForOverwrite not
				or: [self
						overwriteDialogHierarchyChange: hierarchyChange
						higher: higher
						sourceClassName: srcClassOrMeta name
						destinationClassName: dstClassOrMeta name
						methodSelector: methodSel])
				and: [self
						message: methodSel
						compileInClass: dstClassOrMeta
						fromClass: srcClassOrMeta
						dstMessageCategory: dstMessageCategorySel
						srcMessageCategory: srcMessageCategorySel
						internal: internal
						copySemantic: copyFlag].
	^ success