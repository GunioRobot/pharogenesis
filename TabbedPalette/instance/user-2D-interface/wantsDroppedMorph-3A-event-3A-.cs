wantsDroppedMorph: aMorph event: evt
	(tabsMorph bounds containsPoint: (self pointFromWorld: evt cursorPoint)) ifTrue:
		[^ false  "unless it's a book, perhaps, someday"].
	^ currentPage == nil or: [currentPage wantsDroppedMorph: aMorph event: evt]