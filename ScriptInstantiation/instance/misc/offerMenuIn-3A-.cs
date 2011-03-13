offerMenuIn: aStatusViewer
	"Put up a menu."

	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.
	(player class instanceCount > 1) ifTrue:
		[aMenu add: 'propagate status to siblings' selector: #assignStatusToAllSiblingsIn: argument: aStatusViewer.
		aMenu balloonTextForLastItem: 'Make the status of this script in all of my sibling instances be the same as the status you see here'].
	aMenu add: 'grab this object' target: player selector: #grabPlayerIn: argument: self currentWorld.
	aMenu add: 'open this script''s scriptor' target: player selector: #grabScriptorForSelector:in: argumentList: {selector. aStatusViewer world}.
	aMenu popUpInWorld: self currentWorld