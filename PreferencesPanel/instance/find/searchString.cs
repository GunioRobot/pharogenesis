searchString
	"Answer the current searchString, initializing it if need be"

	 | win aMorph |
searchString isEmptyOrNil ifTrue: 
		[searchString _ 'Type here, hit Search'.
		(win _ self containingWindow) ifNotNil:
			[aMorph _ win findDeepSubmorphThat:
					[:m | m isKindOf: PluggableTextMorph]
				ifAbsent: [^ searchString].
			aMorph setText: searchString.
			aMorph setTextMorphToSelectAllOnMouseEnter.
			aMorph selectAll]].
	^ searchString