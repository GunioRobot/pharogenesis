addSoundtrack
	"Add a soundtrack to this JPEG movie."

	| result soundFileName menu compression |
	(mpegFile isKindOf: JPEGMovieFile) ifFalse: [^ self].  "do nothing if not a JPEG movie"

	result _ StandardFileMenu oldFile.
	result ifNil: [^ self].
	soundFileName _ result directory pathName, FileDirectory slash, result name.

	menu _ CustomMenu new title: 'Compression type:'.
	menu addList: #(
		('none (353 kbps)' none)
		('mulaw (176 kbps)' mulaw)
		('adpcm5 (110 kbps)' adpcm5)
		('adpcm4 (88 kbps)' adpcm4)
		('adpcm3 (66 kbps)' adpcm3)
		('gsm (36 kbps)' gsm)).
	compression _ menu startUp.
	compression ifNil: [^ self].

	mpegFile closeFile.
	JPEGMovieFile
		addSoundtrack: soundFileName
		toJPEGMovieNamed: mpegFile fileName
		compressionType: compression.
	self openFileNamed: mpegFile fileName.
