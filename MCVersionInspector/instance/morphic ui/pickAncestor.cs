pickAncestor
	| index versions |
	versions := self version info breadthFirstAncestors.
	index := (PopUpMenu labelArray: (versions collect: [:ea | ea name]))
				startUpWithCaption: 'Ancestor:'.
	^ index = 0 ifFalse: [versions at: index]