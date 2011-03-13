getRecentLocatorWithPrompt: aPrompt
	"Prompt with a menu of how far back to go.  Return nil if user backs out.  Otherwise return the number of characters back from the end of the .changes file the user wishes to include"
	 "ChangeList getRecentPosition"
	| end changesFile banners positions pos chunk i |
	changesFile _ (SourceFiles at: 2) readOnlyCopy.
	banners _ OrderedCollection new.
	positions _ OrderedCollection new.
	end _ changesFile size.
	pos _ SmalltalkImage current lastQuitLogPosition.
	[pos = 0 or: [banners size > 20]] whileFalse:
		[changesFile position: pos.
		chunk _ changesFile nextChunk.
		i _ chunk indexOfSubCollection: 'priorSource: ' startingAt: 1.
		i > 0 ifTrue: [positions addLast: pos.
					banners addLast: (chunk copyFrom: 5 to: i-2).
					pos _ Number readFrom: (chunk copyFrom: i+13 to: chunk size)]
			ifFalse: [pos _ 0]].
	changesFile close.
	pos _ UIManager default chooseFrom: banners values: positions title: aPrompt.
	pos == nil ifTrue: [^ nil].
	^ end - pos