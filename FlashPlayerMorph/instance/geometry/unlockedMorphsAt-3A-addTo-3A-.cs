unlockedMorphsAt: pt addTo: mList
	"The player clips its children"
	(bounds containsPoint: pt) ifFalse:[^mList].
	^super unlockedMorphsAt: pt addTo: mList