assureStartupStampLogged
	"If there is a startup stamp not yet actually logged to disk, do it now."
	| changesFile |
	StartupStamp ifNil: [^ self].
	(SourceFiles isNil or: [(changesFile _ SourceFiles at: 2) == nil]) ifTrue: [^ self].

	changesFile setToEnd; cr; cr.
	changesFile nextChunkPut: StartupStamp asString; cr.
	StartupStamp _ nil.
	self forceChangesToDisk.