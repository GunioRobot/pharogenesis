selectUnchangedMethods
	"Selects all method definitions for which there is already a method in the current image, whose source is exactly the same.  9/18/96 sw"
	| change class systemChanges |
	Cursor read showWhile: 
	[1 to: changeList size do:
		[:i | change _ changeList at: i.
		listSelections at: i put:
			((change type = #method and:
				[(class _ change methodClass) notNil]) and:
					[(class includesSelector: change methodSelector) and:
						[change string = (class sourceCodeAt: change methodSelector)]])]].
	self changed: #allSelections