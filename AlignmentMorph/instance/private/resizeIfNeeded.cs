resizeIfNeeded
	"Resize this morph if it is space-filling or shrink-wrap and its owner is not a layout morph."

	| newWidth newHeight |
	newWidth _ bounds width.
	newHeight _ bounds height.

	(owner == nil or: [owner isAlignmentMorph not]) ifTrue:
		"if spaceFill and not in a LayoutMorph, grow to enclose submorphs"
		[hResizing = #spaceFill ifTrue:
			[newWidth _ self minWidth max: self bounds width.
			owner ifNotNil:
				[(self hasProperty: #clipToOwnerWidth) ifTrue:
					[newWidth _ newWidth min: (owner right - bounds left)]]].
		vResizing = #spaceFill ifTrue:
			[newHeight _ self minHeight max: self bounds height]].

	"if shrinkWrap, adjust size to just fit around submorphs"
	hResizing = #shrinkWrap ifTrue: [newWidth _ self minWidth].
	vResizing = #shrinkWrap ifTrue: [newHeight _ self minHeight].

	((newWidth ~= bounds width) or: [newHeight ~= bounds height])
		ifTrue: ["bounds really changed"
				bounds _ bounds origin extent: newWidth@newHeight].
