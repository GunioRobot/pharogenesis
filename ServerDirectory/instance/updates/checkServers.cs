checkServers
	"Check that all servers are up and have the latest Updates.list.
Warn user when can't write to a server that can still be read."

	| final fileSize this serverList theUpdates decided myUpdates abort |
	serverList _ group
			ifNil: [Array with: self]
			ifNotNil: [group value].
	final _ OrderedCollection new.
	fileSize _ 0.  theUpdates _ ''.	"list of updates"
	abort _ false.
	serverList do: [:aServer |
		decided _ false.
		this _ aServer getFileNamed: 'updates.list'.
		(this = #error:) ifTrue: [^'' "Not found"].
		this class == String ifTrue: ["no ftp"
			(PopUpMenu labels: 'Cancel entire update' withCRs)
				startUpWithCaption: 'Server ', aServer moniker,
				' is unavailable.\Please consider phoning the administator.\' withCRs, this.
			abort _ true.
			decided _ true].
		decided not & (this size > fileSize) ifTrue: ["new has a longer update.list"
			fileSize _ this size.
			final do: [:each | abort _ self outOfDate: each].
			(final _ OrderedCollection new) add: aServer.
			theUpdates _ this contentsOfEntireFile.
			decided _ true].
		decided not & (this size < fileSize) ifTrue: [
			abort _ self outOfDate: aServer.  decided _ true].
		decided not ifTrue: [myUpdates _ this contentsOfEntireFile.
			myUpdates = theUpdates
				ifTrue: [final add: aServer]
				ifFalse: [abort _ self outOfDate: this]].
		abort ifTrue: [^ Array new].
		].
	^ final

