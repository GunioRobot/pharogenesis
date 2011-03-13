allOpenViewersOnReceiverAndSiblings
	"Answer a list of all the viewers open on the receiver and any of its sibling instances.  Include viewers in closed flaps"

	| aWorld all |
	(aWorld _ self costume world) ifNil: [^ #()].
	all _ aWorld allMorphs.
	aWorld closedViewerFlapTabs do:
		[:aTab | all addAll: aTab referent allMorphs].
	^ all select:
		[:m | (m isKindOf: StandardViewer) and: [m scriptedPlayer class == self class]]