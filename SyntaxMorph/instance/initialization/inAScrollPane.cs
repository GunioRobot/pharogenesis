inAScrollPane

	| widget |

	widget _ TwoWayScrollPane new.
	widget extent: 10@10;
		borderWidth: 0.
	widget scroller addMorph: self.
	widget setScrollDeltas.
	^widget

