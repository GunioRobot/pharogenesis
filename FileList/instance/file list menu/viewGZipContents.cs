viewGZipContents
	"View the contents of a gzipped file"
	| f |
	f _ (directory readOnlyFileNamed: self fullName).
	contents _ f contentsOfEntireFile.
	Cursor wait showWhile:[contents _ (GZipReadStream on: contents) upToEnd].
	contents replaceAll: Character lf with: Character cr.
	(StringHolder new)
		contents: contents;
		openLabel:'Contents of ', fileName printString