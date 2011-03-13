glyphIndexAt: position
	| offset |
	offset _ (position adhereTo: (bounds insetBy: 1)) - bounds origin.
	offset _ (offset asFloatPoint / bounds extent) * 16.
	offset _ offset truncated.
	^offset y * 16 + offset x