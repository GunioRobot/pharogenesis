strictlyStaggeredInitialFrameFor: aStandardSystemView
	"This method implements a staggered window placement policy that I like.
	Basically it provides for up to 4 windows, staggered from each of the 4 corners.
	The windows are staggered so that there will always be a corner visible.
	"
	| allowedArea grid initialFrame allWindows cornerSel corner delta putativeCorner free maxLevel |
	allowedArea _ ScrollBarSetback @ ScreenTopSetback
					corner: Display usableArea bottomRight.
	"Number to be staggered at each corner (less on small screens)"
	maxLevel _ allowedArea area > 300000 ifTrue: [3] ifFalse: [2].
	"Amount by which to stagger (less on small screens)"
	grid _ allowedArea area > 500000 ifTrue: [40] ifFalse: [20].
	initialFrame _ 0@0 extent: ((aStandardSystemView initialExtent
							"min: (allowedArea extent - (grid*(maxLevel+1*2) + (grid//2))))
							min: 600@400")).
	allWindows _ ScheduledControllers scheduledWindowControllers
				select: [:aController | aController view ~~ nil]
				thenCollect: [:aController | aController view isCollapsed
								ifTrue: [aController view expandedFrame]
								ifFalse: [aController view displayBox]].
	0 to: maxLevel do:
		[:level | 
		1 to: 4 do:
			[:ci | cornerSel _ #(topLeft topRight bottomRight bottomLeft) at: ci.
			corner _ allowedArea perform: cornerSel.
			"The extra grid//2 in delta helps to keep title tabs distinct"
			delta _ (maxLevel-level*grid+(grid//2)) @ (level*grid).
			1 to: ci-1 do: [:i | delta _ delta rotateBy: #right centerAt: 0@0]. "slow way"
			putativeCorner _ corner + delta.
			free _ true.
			allWindows do:
				[:w |
				free _ free & ((w perform: cornerSel) ~= putativeCorner)].
			free ifTrue:
				[^ (initialFrame align: (initialFrame perform: cornerSel)
								with: putativeCorner)
						 squishedWithin: allowedArea]]].
	"If all else fails..."
	^ (ScrollBarSetback @ ScreenTopSetback extent: initialFrame extent)
		squishedWithin: allowedArea