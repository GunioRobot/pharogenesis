thumbnailForPartsDescription: aPartsDescription
	"Answer a thumbnail for the given parts description creating it if necessary.  If it is created afresh, it will also be cached at this time"

	| aThumbnail aSymbol |
	aSymbol _ aPartsDescription formalName asSymbol.
	^ Thumbnails at: aSymbol ifAbsent:
		[aThumbnail _ Thumbnail new makeThumbnailFromForm: aPartsDescription sampleImageForm.
		self cacheThumbnail: aThumbnail forSymbol: aSymbol.
		^ aThumbnail]

"PartsBin initialize"