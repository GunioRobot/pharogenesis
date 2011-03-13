openPath: anArray

	anArray isEmpty ifTrue: [^container setSelectedMorph: nil].
	self withSiblingsDo: [:each | 
		(each complexContents asString = anArray first or: [anArray first isNil]) ifTrue: [
			each isExpanded ifFalse: [
				each toggleExpandedState.
				container installEventHandlerOn: each children.
				container adjustSubmorphPositions.
			].
			each changed.
			anArray size = 1 ifTrue: [
				^container setSelectedMorph: each
			].
			each firstChild ifNil: [^container setSelectedMorph: nil].
			^each firstChild openPath: anArray allButFirst.
		].
	].
	^container setSelectedMorph: nil

