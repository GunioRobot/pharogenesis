checkServers
	"Check that all servers are up and have the latest Updates.list.  Return the servers that ready to receiver this update"

	| final fileSize this serverList theUpdates decided myUpdates abort strm res |
	serverList _ group 
			ifNil: [Array with: self] 
			ifNotNil: [group value].
	final _ OrderedCollection new.
	fileSize _ 0.  theUpdates _ ''.	"list of updates"
	abort _ false.
	serverList do: [:aServer |
		decided _ false.
		this _ aServer getFileNamed: 'updates.list'.
		(this class == String) & (url size > 0) ifTrue: [
			strm _ HTTPSocket httpGet: url accept: 'application/octet-stream'.
			strm class == String 
				ifTrue: [res _ (PopUpMenu  
						labels: 'Install even though not visible\Cancel entire update' withCRs)
						startUpWithCaption: 'Server ', aServer moniker, 
						' is a weird state.\You cannot store, but users can get updates.\If you store on other servers, the file will not be visible.\Strongly advise that you Cancel.' withCRs]
				ifFalse: [
					res _ (PopUpMenu labels: 'Install on others\Cancel entire update' withCRs)
							startUpWithCaption: 'Server ', aServer moniker, 
							' is unavailable\' withCRs, this].
			abort _ res ~= 1.
			decided _ true].
		decided not & (this size > fileSize) ifTrue: ["new has a longer update.list"
			fileSize _ this size.
			final do: [:each | abort _ self outOfDate: each].
			(final _ OrderedCollection new) add: aServer.
			theUpdates _ this contentsOfEntireFile. 
			decided _ true].
		decided not & (this size < fileSize) ifTrue: [abort _ self outOfDate: aServer.  decided _ true].
		decided not ifTrue: [myUpdates _ this contentsOfEntireFile.
			myUpdates = theUpdates 
				ifTrue: [final add: aServer]
				ifFalse: [abort _ self outOfDate: this]].
		abort ifTrue: [^ Array new].
		].
	^ final

