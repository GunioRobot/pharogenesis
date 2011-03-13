labelList: labelList lines: lines selections: selections
	| topLabels topSelections deeperMenus item j |
	topLabels _ OrderedCollection new.
	topSelections _ OrderedCollection new.
	deeperMenus _ OrderedCollection new.
	j _ 0.
	1 to: labelList size do:
		[:i | item _ labelList at: i.
		(item isMemberOf: Array)
			ifTrue: [topLabels addLast: item first.
					deeperMenus addLast:
					(HierarchicalMenu labelList: (item copyFrom: 2 to: item size)
						selections: (selections at: i))]
			ifFalse: [topLabels addLast: item.
					deeperMenus addLast: nil].
		
		topSelections addLast: (selections at: i)].
	^ (super labelList: topLabels asArray lines: lines selections: topSelections asArray)
		deeperMenus: deeperMenus asArray