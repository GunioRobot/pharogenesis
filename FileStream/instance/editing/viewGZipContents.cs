viewGZipContents
	"View the contents of a gzipped file"

	| stringContents |
	self binary.
	stringContents _ self contentsOfEntireFile.
	Cursor wait showWhile: [stringContents _ (GZipReadStream on: stringContents) upToEnd].
	stringContents _ stringContents asString withSqueakLineEndings.

	Workspace new
		contents: stringContents;
		openLabel: 'Decompressed contents of: ', self localName