upLoadProject: projectName members: archiveMembers retry: aBool
	| dir okay m dirName idx |
	m _ archiveMembers detect:[:any| any fileName includes: $/] ifNone:[nil].
	m == nil ifFalse:[
		dirName _ m fileName copyUpTo: $/.
		self createDirectory: dirName.
		dir _ self directoryNamed: dirName].
	archiveMembers do:[:entry|
		ProgressNotification signal: '4:uploadingFile'
			extra: ('(uploading {1}...)' translated format: {entry fileName}).
		idx _ entry fileName indexOf: $/.
		okay _ (idx > 0
			ifTrue:[
				dir putFile: entry contentStream 
					named: (entry fileName copyFrom: idx+1 to: entry fileName size) 
					retry: aBool]
			ifFalse:[
				self putFile: entry contentStream
					named: entry fileName
					retry: aBool]).
		(okay == false
			or: [okay isString])
			ifTrue: [
				self inform: ('Upload for {1} did not succeed ({2}).' translated format: {entry fileName printString. okay}).
				^false].
	].
	ProgressNotification signal: '4:uploadingFile' extra:''.
	^true