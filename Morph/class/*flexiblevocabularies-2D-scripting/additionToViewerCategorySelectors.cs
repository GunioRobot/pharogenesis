additionToViewerCategorySelectors
	"Answer the list of my selectors matching additionsToViewerCategory*"
	^self class organization allMethodSelectors select: [ :ea |
		(ea beginsWith: 'additionsToViewerCategory')
					and: [ (ea at: 26 ifAbsent: []) ~= $: ]]