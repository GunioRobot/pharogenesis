chooseHaloSubmorphOf: root caption: caption
	"Answer the submorph of the root that should be given the halo"

	^ (root unlockedMorphsAt: targetOffset) first