newVersion: fileNameAndNumberPair
	| resp versHere |
	"Figure out what the next version should be and return as a Mime Encoded base 64 number, HTTP encoded (for the slash)"

	fileNameAndNumberPair first
		ifNil: [version 
			ifNil: ["not on server and ours is new"  ^ 'AA']
			ifNotNil: ["not on server and we have stored before" 
					^ Project bumpVersion: version]]
		ifNotNil: [version 
			ifNil: ["on server already, and ours has never been stored"
				resp _ (PopUpMenu labels: 'Store\Cancel' withCRs) startUpWithCaption: 
				'Replace project ', self name, ' on the server',
				'\with this completely new and unrelated version?' withCRs.
				resp ~= 1 ifTrue: [^ nil].
				^ Project bumpVersion: fileNameAndNumberPair second]
			ifNotNil: ["present on server, and we expect that.  Compare numbers"
				versHere _ Base64MimeConverter decodeInteger: version unescapePercents.
				versHere < fileNameAndNumberPair second ifTrue: ["Warn of intervening versions"
					resp _ (PopUpMenu labels: 'Store anyway\Cancel' withCRs) startUpWithCaption: 
						'There is a newer version of project ', self name, ' on the server.',
						'\Please cancel, rename this project, and see what is there.' withCRs.
						resp ~= 1 ifTrue: [^ nil]].
				^ Project bumpVersion: (versHere max: fileNameAndNumberPair second)]].
