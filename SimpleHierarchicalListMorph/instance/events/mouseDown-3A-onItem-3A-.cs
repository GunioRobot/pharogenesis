mouseDown: event onItem: aMorph

	| oldState |
	(aMorph inToggleArea: event) ifTrue: [
		"self setSelectedMorph: aMorph."
		event yellowButtonPressed ifTrue: [
			oldState _ aMorph isExpanded.
			scroller submorphs copy do: [ :each |
				(each canExpand and: [each isExpanded = oldState]) ifTrue: [
					each toggleExpandedState.
					self installEventHandlerOn: each children.
				].
			].
		] ifFalse: [
			aMorph toggleExpandedState.
			self installEventHandlerOn: aMorph children.
		].
		self adjustSubmorphPositions.
		^self
	].
	event yellowButtonPressed ifTrue: [^ self yellowButtonActivity: event shiftPressed].
	model okToChange ifFalse: [^ self].  "No change if model is locked"
	((autoDeselect == nil or: [autoDeselect]) and: [aMorph == selectedMorph])
		ifTrue: [self setSelectedMorph: nil]
		ifFalse: [self setSelectedMorph: aMorph].
