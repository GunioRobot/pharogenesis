yellowButtonActivity
	"Put up the alternate yellow button activity if appropriate, else defer to the old way.  2/7/96 sw
	 5/8/96 sw: if shift key down, do find window.
	 7/23/96 sw: project screen menu different from regular (top) screen menu"

	| reply aMenu |
	Sensor leftShiftDown ifTrue: [^ self findWindow].

	aMenu _ Project current isTopProject
		ifFalse:
			[self projectScreenMenu]
		ifTrue:
			[self topScreenMenu].
	(reply _ aMenu startUp) isNil ifTrue: [^ super controlActivity].
	(#(changesMenu helpMenu openMenu windowMenu miscMenu) includes: reply)
		ifTrue:  "submenu called for"
			[reply _ (self perform: reply) startUp.
			reply == nil ifTrue: [^ super controlActivity]].
	^ self perform: reply