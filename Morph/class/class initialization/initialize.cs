initialize
	"Morph initialize"

	"this empty array object is shared by all morphs with no submorphs:"
	EmptyArray _ Array new.
	FileList registerFileReader: self