browseRecentLog    "ChangeList browseRecentLog"
	"Prompt with a menu of how far back to go"
	| end changesFile banners positions pos chunk i |
	changesFile _ (SourceFiles at: 2) readOnlyCopy.
	banners _ OrderedCollection new.
	positions _ OrderedCollection new.
	end _ changesFile size.
	pos _ Smalltalk lastQuitLogPosition.
	[pos = 0 or: [banners size > 20]] whileFalse:
		[changesFile position: pos.
		chunk _ changesFile nextChunk.
		i _ chunk indexOfSubCollection: 'priorSource: ' startingAt: 1.
		i > 0 ifTrue: [positions addLast: pos.
					banners addLast: (chunk copyFrom: 5 to: i-2).
					pos _ Number readFrom: (chunk copyFrom: i+13 to: chunk size)]
			ifFalse: [pos _ 0]].
	changesFile close.
	pos _ (SelectionMenu labelList: banners reversed selections: positions reversed)
				startUpWithCaption: 'Browse as far back as...'.
	pos == nil ifTrue: [^ self].
	self browseRecent: end-pos