doMenu: evt with: menuHandle
	"Ask hand to invoke the halo menu for my inner target."

	| menu |
	evt hand obtainHalo: self.
	self removeAllHandlesBut: nil.  "remove all handles"
	self world displayWorld.
	menu _ innerTarget buildHandleMenu: evt hand.
	innerTarget mightEntertainDirectionHandles ifTrue:
		[self showingDirectionHandles
			ifTrue: [menu add: 'hide direction handles' target: self selector: #showDirectionHandles: argument: false]
			ifFalse: [menu add: 'show direction handles' target: self selector: #showDirectionHandles: argument: true]].
	innerTarget addTitleForHaloMenu: menu.
	menu popUpEvent: evt in: self world.
