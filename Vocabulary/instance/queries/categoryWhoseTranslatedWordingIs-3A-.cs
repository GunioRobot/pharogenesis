categoryWhoseTranslatedWordingIs: aWording
	"Answer the category whose translated is the one provided, or nil if none"

	^ self categories detect: [:aCategory | aCategory wording = aWording] ifNone: [nil]
