addPenTrailsMenuItemsTo: aMenu
	| oldTarget |
	"Add items relating to pen trails to aMenu"

	oldTarget _ aMenu defaultTarget.
	aMenu defaultTarget: self.
	aMenu add: 'clear pen trails' action: #clearTurtleTrails.
	aMenu add: 'all pens up' action: #liftAllPens.
	aMenu add: 'all pens down' action: #lowerAllPens.
	aMenu defaultTarget: oldTarget