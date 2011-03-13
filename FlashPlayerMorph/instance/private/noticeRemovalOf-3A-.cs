noticeRemovalOf: aFlashMorph
	"The flash morph is removed from the player.
	Remove it's activation keys so that we don't have any problems."
	| morphs |
	aFlashMorph activationKeys do:[:key|
		morphs := activationKeys at: key.
		activationKeys at: key put: (morphs copyWithout: aFlashMorph).
	].
	"And remove it from the activeMorphs"
	activeMorphs remove: aFlashMorph ifAbsent:[]