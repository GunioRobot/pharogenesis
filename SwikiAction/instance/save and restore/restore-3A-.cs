restore: nameOfSwiki
	"Read all files in the directory 'nameOfSwiki'.  Reconstruct the url map."

	| map page folder dir rep templateFolder |
	map _ URLmap new.
	self map: map.
	self name: nameOfSwiki.
	templateFolder _ 'swiki'.
	self source: templateFolder,(ServerAction pathSeparator).
	map action: self.
	map pages: (Dictionary new).
	map directory: nameOfSwiki. "This is where the pages are."
	folder _ (ServerAction serverDirectory), nameOfSwiki.
	dir _ FileDirectory on: folder.
	dir fileNames do: [:fName |
		rep _ fName detect: [:char | char isDigit not] ifNone: [$3].
		rep isDigit ifTrue: ["all are digits"
			page _ self class pageClass new.
			page fromFileNamed: folder,(ServerAction pathSeparator),fName action: self.
			map at: page name put: page]].
	PWS link: nameOfSwiki to: self.
