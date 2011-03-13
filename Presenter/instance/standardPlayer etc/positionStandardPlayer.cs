positionStandardPlayer
	| aPosition standardPlayerMorph |
	standardPlayerMorph _ standardPlayer costume.
	aPosition _ associatedMorph positionNear: (associatedMorph bottomLeft + (4 @ (standardPlayerMorph height negated))) forExtent: standardPlayerMorph extent adjustmentSuggestion: (standardPlayerMorph width @ 0).
	standardPlayerMorph position: aPosition