initialize
	"SqueakPageCache initialize"

	GlobalPolicy _ #neverWrite.
	PageCache _ Dictionary new: 100.
		"forgets urls of pages, but ObjectOuts still remember them"
