chooseHaloSubmorphOf: root caption: caption
	"Answer the submorph of the root that should be given the halo; in etoys, we never prompt the user, but for generic Morphic, we do it Ted's way"
	^ self chooseTargetSubmorphOf: root caption: caption