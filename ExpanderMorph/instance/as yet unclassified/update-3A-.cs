update: aspect
	"Update the receiver."

	aspect = #expanded
		ifTrue: [self vResizing: (self expanded
					ifTrue: [#spaceFill]
					ifFalse: [#shrinkWrap]).
				self showMorphs: self expanded.
				self fixLayout]