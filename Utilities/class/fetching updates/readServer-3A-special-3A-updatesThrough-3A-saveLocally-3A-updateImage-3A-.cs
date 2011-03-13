readServer: serverList special: indexPrefix updatesThrough: maxNumber saveLocally: saveLocally updateImage: updateImage
	"Scan the update server(s) for unassimilated updates. If maxNumber is not nil, it represents the highest-numbered update to load.  This makes it possible to update only up to a particular point.   If saveLocally is true, then save local copies of the update files on disc.  If updateImage is true, then absorb the updates into the current image."

"Utilities readServer: Utilities serverUrls updatesThrough: 828 saveLocally: true updateImage: true"

	| urls failed loaded docQueue this nextDoc docQueueSema str updateName |
	Cursor wait showWhile: [

	urls := self newUpdatesOn: (serverList collect: [:url | url, 'updates/']) 
				special: indexPrefix
				throughNumber: maxNumber.
	loaded := 0.
	failed := nil.

	"send downloaded documents throuh this queue"
	docQueue := SharedQueue new.

	"this semaphore keeps too many documents from beeing queueed up at a time"
	docQueueSema := Semaphore new.
	5 timesRepeat: [ docQueueSema signal ].

	"fork a process to download the updates"
	self retrieveUrls: urls ontoQueue: docQueue withWaitSema: docQueueSema.

	"process downloaded updates in the foreground"
	'Processing updates' displayProgressAt: Sensor cursorPoint from: 0 to: urls size during: [:bar |
	[ this := docQueue next.
	  nextDoc := docQueue next.  
	  nextDoc = #failed ifTrue: [ failed := this ].
	  (failed isNil and: [ nextDoc ~= #finished ])
	] whileTrue: [
		failed ifNil: [
			nextDoc reset; text.
			nextDoc size = 0 ifTrue: [ failed := this ]. ].
		failed ifNil: [
			nextDoc peek asciiValue = 4	"pure object file"
				ifTrue: [failed := this]].	"Must be fileIn, not pure object file"
		failed ifNil: [
			"(this endsWith: '.html') ifTrue: [doc _ doc asHtml]."
				"HTML source code not supported here yet"
			updateImage
				ifTrue: [
					updateName := (this findTokens: '/') last.
					ChangeSet newChangesFromStream: nextDoc named: updateName.
					SystemVersion current registerUpdate: updateName initialIntegerOrNil].
			saveLocally ifTrue:
				[self saveUpdate: nextDoc onFile: (this findTokens: '/') last].	"if wanted"
			loaded := loaded + 1.
			bar value: loaded].

		docQueueSema signal].
	]].

	failed ~~ nil & (urls size - loaded > 0) ifTrue: [
		str := loaded printString ,' new update file(s) processed.'.
		str := str, '\Could not load ' withCRs, 
			(urls size - loaded) printString ,' update file(s).',
			'\Starting with "' withCRs, failed, '".'.
		self inform: str].
	^ Array with: failed with: loaded
