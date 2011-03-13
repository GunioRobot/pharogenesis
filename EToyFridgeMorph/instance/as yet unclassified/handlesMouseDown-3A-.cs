handlesMouseDown: globalEvt

	| localCursorPoint |
	localCursorPoint _ self globalPointToLocal: globalEvt cursorPoint.
	groupMode ifFalse: [
		self allMorphsDo: [ :each |
			(each isKindOf: EToySenderMorph) ifTrue: [
				(each bounds containsPoint: localCursorPoint) ifTrue: [^false].
			].
		].
	].
	^true