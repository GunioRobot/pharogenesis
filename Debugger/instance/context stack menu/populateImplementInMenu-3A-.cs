populateImplementInMenu: aMenu

	| msg |
	msg _ self selectedContext at: 1.
	self selectedContext receiver class withAllSuperclasses do:
		[:each |
		aMenu add: each name target: self selector: #implement:inClass: argumentList: (Array with: msg with: each)].
	^ aMenu

