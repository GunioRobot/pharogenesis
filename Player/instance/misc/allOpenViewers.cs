allOpenViewers
	"Answer a list of all the viewers open on the receiver"
	| aWorld |
	(aWorld _ self costume world) ifNil: [^ #()].
	^ aWorld allMorphs select:
		[:m | (m isKindOf: StandardViewer) and: [m scriptedPlayer == self]]