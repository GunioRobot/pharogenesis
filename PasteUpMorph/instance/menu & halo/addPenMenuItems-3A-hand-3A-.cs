addPenMenuItems: menu hand: aHandMorph
	| subMenu |
	subMenu _ MenuMorph new defaultTarget: self.
	subMenu add: 'clear pen trails' action: #clearTurtleTrails.
	subMenu add: 'all pens up' action: #liftAllPens.
	subMenu add: 'all pens down' action: #lowerAllPens.
	menu add: 'pens trails within...' subMenu: subMenu