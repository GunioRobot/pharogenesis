reclaimPanes
	| reclaimed |
	reclaimed := model reclaimPanes.
	reclaimed isZero	ifFalse: 
		[self 
		 	popPanes: reclaimed;
			basicUpdateSizing;
			layoutPanes;
			hideOrShowScrollBar;
			setScrollDeltas]