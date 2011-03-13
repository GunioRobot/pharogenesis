viewGZipContents
	"View the contents of a gzipped file"

	| stringContents |
	self binary.
	stringContents := self contentsOfEntireFile.
	Cursor wait showWhile: [stringContents := (GZipReadStream on: stringContents) upToEnd].
	stringContents := stringContents asString withSqueakLineEndings.

	Workspace new
		contents: stringContents;
		openLabel: 'Decompressed contents of: ', self localName