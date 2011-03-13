addScalingMenuItems: menu hand: aHandMorph

	| subMenu |

	(subMenu _ MenuMorph new)
		defaultTarget: self;
		add: 'show application view' action: #showApplicationView;
		add: 'show factory view' action: #showFactoryView;
		add: 'show whole world view' action: #showFullView;
		add: 'expand' action: #showExpandedView;
		add: 'reduce' action: #showReducedView;
		addLine;
		add: 'define application view' action: #defineApplicationView;
		add: 'define factory view' action: #defineFactoryView.
	menu
		add: 'world scale and clip...'
		subMenu: subMenu