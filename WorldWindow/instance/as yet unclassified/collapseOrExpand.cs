collapseOrExpand

	super collapseOrExpand.
	isCollapsed ifFalse: [model becomeTheActiveWorldWith: nil]