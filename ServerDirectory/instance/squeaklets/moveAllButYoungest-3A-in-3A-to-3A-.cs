moveAllButYoungest: young in: versions to: repository
	| all fName aVers bVers |
	"Specialized to files with names of the form 'aName_vvv.ext'.  Where vvv is a mime-encoded base 64 version number.  Versions is an array of file names tokenized into three parts (aName vvv ext).  Move the files by renaming them on the server."

	versions size <= young ifTrue: [^ self].
	all _ SortedCollection sortBlock: [:aa :bb | 
		aVers _ Base64MimeConverter decodeInteger: aa second unescapePercents.
		bVers _ Base64MimeConverter decodeInteger: bb second unescapePercents.
		aVers < bVers].
	all addAll: versions.
	young timesRepeat: [all removeLast].	"ones we keep"
	all do: [:vv |
		fName _ vv first, '_', vv second, '.', vv third.
		repository rename: self fullName,fName toBe: fName].
