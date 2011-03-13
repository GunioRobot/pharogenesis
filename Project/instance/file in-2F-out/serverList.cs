serverList
	| swiki bigHACK |

	"Take my list of server URLs and return a list of ServerDirectories to write on.  Each starts with ftp://"

	self flag: #bob.		"BIG hack to try projects on a swiki"
	bigHACK _ false.

	bigHACK ifTrue: [
		(swiki _ SuperSwikiServer currentSuperSwiki) ifNotNil: [
			^{swiki}
		].
	].
	urlList isEmptyOrNil ifTrue: [^ nil].
	^ urlList collect: [:url | Project serverDirectoryFromURL: url]