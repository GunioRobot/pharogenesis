docNamesAt: classAndMethod
	"Return a list of fileNames to try for this method.  'Point x:' is form of classAndMethod."

	| key verList fileNames |
	key _ DocLibrary properStemFor: classAndMethod.
	verList _ methodVersions at: key ifAbsent: [#()].
	fileNames _ OrderedCollection new.
	1 to: verList size by: 2 do: [:ind |
		fileNames addFirst: key,'.',(verList at: ind) printString, '.sp'].
	fileNames addLast: key,'.0.sp'.
	^ fileNames