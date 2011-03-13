rebuild

	| history r1 |
	changeCounter _ ProjectHistory changeCounter.
	history _ ProjectHistory currentHistory mostRecentCopy.
	self removeAllMorphs.
	self rubberBandCells: false. "enable growing"
	r1 _ self addARow: {
		self inAColumn: {
			StringMorph new contents: 'Jump...'; lock.
		}.
	}.
	r1 on: #mouseUp send: #jumpToProject to: self.

	history do: [ :each |
		(
			self addARow: {
				(self inAColumn: {
					StretchyImageMorph new form: each second; minWidth: 35; minHeight: 35; lock
				}) vResizing: #spaceFill.
				self inAColumn: {
					StringMorph new contents: each first; lock.
					"StringMorph new contents: each third; lock."
				}.
			}
		)
			color: Color paleYellow;
			borderWidth: 1;
			borderColor: #raised;
			vResizing: #spaceFill;
			on: #mouseUp send: #mouseUp:in: to: self;
			on: #mouseDown send: #mouseDown:in: to: self;
			on: #mouseMove send: #mouseMove:in: to: self;
			on: #mouseLeave send: #mouseLeave:in: to: self;
			setProperty: #projectParametersTuple toValue: each;
			setBalloonText: (each third isEmptyOrNil ifTrue: ['not saved'] ifFalse: [each third])
	].
"---
	newTuple _ {
		aProject name.
		aProject thumbnail.
		aProject url.
		WeakArray with: aProject.
	}.
---"