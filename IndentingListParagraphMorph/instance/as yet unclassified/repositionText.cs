repositionText

	| sRect tm |
	sRect _ self textMorphBounds.
	(tm _ complexContents withoutListWrapper)
		"clipToOwner: isExpanded not;"
		position: sRect origin;
		width: sRect width.
	isExpanded ifTrue: [
		tm extent: sRect width@10.
		tm contents: tm contents wrappedTo: sRect width.
		tm extent: sRect width@10.
	] ifFalse: [
		tm contentsAsIs: tm contents.
		tm extent: tm extent.		"force bounds recompute"
	].
	tm lock: isExpanded not.
"{tm. tm bounds. sRect} explore."
	^tm
