browseRecentLogOn: origChangesFile 
	"figure out where the last snapshot or quit was, then browse the recent entries."

	| end done block pos chunk changesFile positions prevBlock |
	changesFile _ origChangesFile readOnlyCopy.
	positions _ SortedCollection new.
	end _ changesFile size.
	prevBlock _ end.
	block _ end - 1024 max: 0.
	done _ false.
	[done
		or: [positions size > 0]]
		whileFalse: [changesFile position: block.
			"ignore first fragment"
			changesFile nextChunk.
			[changesFile position < prevBlock]
				whileTrue: [pos _ changesFile position.
					chunk _ changesFile nextChunk.
					((chunk indexOfSubCollection: '----' startingAt: 1) = 1) ifTrue: [
						({ '----QUIT'. '----SNAPSHOT' } anySatisfy: [ :str |
							chunk beginsWith: str ])
								ifTrue: [positions add: pos]]].
			block = 0
				ifTrue: [done _ true]
				ifFalse: [prevBlock _ block.
					block _ block - 1024 max: 0]].
	changesFile close.
	positions isEmpty
		ifTrue: [self inform: 'File ' , changesFile name , ' does not appear to be a changes file']
		ifFalse: [self browseRecentLogOn: origChangesFile startingFrom: positions last]