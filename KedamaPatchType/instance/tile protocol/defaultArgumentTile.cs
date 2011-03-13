defaultArgumentTile
	"Answer a tile to represent the type"
	| patch ks k p |
	patch _ KedamaPatchTile new typeColor: self typeColor.
	ks _ ActiveWorld allMorphs select: [:e | e isKindOf: KedamaMorph].
	ks isEmpty ifFalse: [
		k _ ks first.
		p _ k player getPatch.
	] ifTrue: [
		k _ KedamaPatchMorph new.
		k assuredPlayer.
		p _ k player.
	].
	patch usePatch: p.
	^ patch.
