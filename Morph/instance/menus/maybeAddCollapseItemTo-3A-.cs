maybeAddCollapseItemTo: aMenu
	self topRendererOrSelf owner isWorldMorph ifTrue:
		[aMenu add: #collapse target: self action: #collapse]