changeFont
	| newFont |
	newFont _ StrikeFont fromUser: self fontToUse.
	newFont ifNotNil:[self font: newFont].