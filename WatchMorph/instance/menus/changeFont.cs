changeFont

	self fontName: ((SelectionMenu labelList: StrikeFont familyNames
							selections: StrikeFont familyNames) startUp
					ifNil: [^ self])