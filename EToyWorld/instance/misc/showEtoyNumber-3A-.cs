showEtoyNumber: ind
	"Show that etoy, from the list I have"

	| holderToInstall |
	frontCover ifNotNil: [
		userName _ (frontCover findA: TextMorph) contents asString].

	BookMorph turnOffSoundWhile: [
		holderToInstall _ etoys at: ind.
		holderToInstall internalizeIfNecessary.
		EToyPlayer new initializeFor: holderToInstall inWorld: self].

	Display wipeImage: self imageForm at: viewBox origin delta: -1@0 clippingBox: self viewBox.
