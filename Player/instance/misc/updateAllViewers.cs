updateAllViewers
	"The receiver's structure has changed, so viewers on it need to be reconstituted."

	| aPresenter viewers |
	(aPresenter _ self costume presenter) ifNil: [^ self].

	viewers _ self costume world allMorphs select:
		[:m | (m isKindOf: PartsViewer) and: [m scriptedPlayer == self]].

	viewers do: [:m | aPresenter updatePartsViewer: m]
	"overkill, removes player from viewer cache repeatedly"