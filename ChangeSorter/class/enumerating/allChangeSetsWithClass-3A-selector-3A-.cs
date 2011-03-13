allChangeSetsWithClass: class selector: selector
	class ifNil: [^ #()].
	^ self gatherChangeSets select: 
		[:cs | (cs atSelector: selector class: class) ~~ #none]