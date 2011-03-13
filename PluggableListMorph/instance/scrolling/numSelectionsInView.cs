numSelectionsInView
	"Answer the scroller's height based on the average number of submorphs."
	
	(scroller submorphCount > 0) ifFalse:[ ^0 ].
	
	"ugly hack, due to code smell.
	PluggableListMorph added another level of indirection, 
	There is always only one submorph - a LazyListMorph which holds the actual list,
	but TransformMorph doesn't know that and we are left with a breach of interface.
	
	see vUnadjustedScrollRange for another bad example."
		
	^scroller numberOfItemsPotentiallyInViewWith: (scroller 
												submorphs last getListSize).