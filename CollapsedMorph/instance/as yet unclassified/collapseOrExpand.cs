collapseOrExpand
	isCollapsed
		ifTrue: 
			[uncollapsedMorph setProperty: #collapsedPosition toValue: self position.
			mustNotClose _ false.	"We're not closing but expanding"
			self delete.
			self currentWorld addMorphFront: uncollapsedMorph]
		ifFalse:
			[super collapseOrExpand]