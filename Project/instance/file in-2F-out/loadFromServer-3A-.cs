loadFromServer: newerAutomatically
	"If a newer version of me is on the server, load it."
	| pair resp server |
	self assureIntegerVersion.

	self isCurrentProject ifTrue: ["exit, then do the command"
		^ self armsLengthCommand: #loadFromServer withDescription: 'Loading' translated
	].
	server _ self tryToFindAServerWithMe ifNil: [^ nil].
	pair _ self class mostRecent: self name onServer: server.
	pair first ifNil: [^ self inform: ('can''t find file on server for {1}' translated format: {self name})].
	self currentVersionNumber > pair second ifTrue: [
		^ self inform: ('That server has an older version of the project.' translated)].
	version = (Project parseProjectFileName: pair first) second ifTrue: [
		resp _ (PopUpMenu labels: 'Reload anyway\Cancel' translated withCRs) startUpWithCaption: 
					'The only changes are the ones you made here.' translated.
		resp ~= 1 ifTrue: [^ nil]
	] ifFalse: [
		newerAutomatically ifFalse: [
			resp _ (PopUpMenu labels: 'Load it\Cancel' translated withCRs) startUpWithCaption: 
						'A newer version exists on the server.' translated.
			resp ~= 1 ifTrue: [^ nil]
		].
	].

	"let's avoid renaming the loaded change set since it will be replacing ours"
	self projectParameters at: #loadingNewerVersion put: true.

	ComplexProgressIndicator new 
		targetMorph: nil;
		historyCategory: 'project loading';
		withProgressDo: [
			ProjectLoading
				installRemoteNamed: pair first
				from: server
				named: self name
				in: parentProject
		]
