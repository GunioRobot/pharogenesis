changeTabText
	| reply |

	reply _ FillInTheBlankMorph request: 'new wording for this tab:' initialAnswer: self existingWording centerAt: self cursorPoint inWorld: self world.
	reply isEmptyOrNil ifTrue: [^ self].
	self useStringTab: reply.
	submorphs first delete.
	self assumeString: reply font: Preferences standardFlapFont orientation: (Utilities orientationForEdge: edgeToAdhereTo) color: nil