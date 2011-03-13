selectNewMethods
	"Selects all method definitions for which there is no counterpart method in the current image"

	| change class |
	Cursor read showWhile: 
		[1 to: changeList size do:
			[:i | change := changeList at: i.
			listSelections at: i put:
				((change type = #method and:
					[((class := change methodClass) isNil) or:
						[(class includesSelector: change methodSelector) not]]))]].
	self changed: #allSelections