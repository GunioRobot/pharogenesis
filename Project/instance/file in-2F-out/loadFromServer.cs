loadFromServer
	| servers pair resp strm |
	"If a newer version of me is on the server, load it."

	self == CurrentProject ifTrue: ["exit, then do the command"
		^ self armsLengthCommand: #loadFromServer].
	(servers _ self serverList) isEmpty 
		ifTrue: [^ self inform: 'This project thinks it has never been on a server'].
	pair _ self class mostRecent: self name onServer: servers first.
	pair first ifNil: [^ self inform: 'can''t find file on server for ', self name].
	(Base64MimeConverter decodeInteger: version unescapePercents) > pair second ifTrue: [
		^ self inform: 'That server has an older version of the project.'].
	version = (pair first findTokens: '|.') second 
		ifTrue: [resp _ (PopUpMenu labels: 'Reload anyway\Cancel' withCRs) startUpWithCaption: 
					'The only changes are the ones you made here.'.
				resp ~= 1 ifTrue: [^ nil]]
		ifFalse: [resp _ (PopUpMenu labels: 'Load it\Cancel' withCRs) startUpWithCaption: 
					'A newer version exists on the server.'.
				resp ~= 1 ifTrue: [^ nil]].
	"Find parent project, go there, zap old thumbnail"
	strm _ servers first oldFileNamed: pair first.
	parentProject installRemoteFrom: strm named: self name.
