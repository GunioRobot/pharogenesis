readServerUpdatesThrough: maxNumber saveLocally: saveLocally updateImage: updateImage
	"Scan the update server(s) for unassimilated updates. If maxNumber is not nil, it represents the highest-numbered update to load.  This makes it possible to update only up to a particular point.   If saveLocally is true, then save local copies of the update files on disc.  If updateImage is true, then absorb the updates into the current image.

A file on the server called updates.list has the names of the last N update files.  We look backwards for the first one we do not have, and start there"
"* To add a new update:  Name it starting with a new two-digit code.  
* Do not use %, /, *, space, or more than one period in the name of an update file.
* The update name does not need to have any relation to the version name.
* Figure out which versions of the system the update makes sense for.
* Add the name of the file to each version's category below.
* Put this file and the update file on all of the servers.
*
* To make a new version of the system:  Pick a name for it (no restrictions)
* Put # and exactly that name on a new line at the end of this file.
* During the release process, fill in exactly that name in the dialog box.
* Put this file on the server."

"Utilities readServerUpdatesThrough: 828 saveLocally: false updateImage: true"
"Utilities readServerUpdatesThrough: 828 saveLocally: true updateImage: true"

	| urls failed loaded str docQueue this nextDoc docQueueSema |
	Utilities chooseUpdateList ifFalse: [^ self].	"ask the user which kind of updates"
	Cursor wait showWhile: [

	urls _ self newUpdatesOn: (Utilities serverUrls collect: [:url | url, 'updates/']) 
				throughNumber: maxNumber.
	loaded _ 0.
	failed _ nil.

	"send downloaded documents throuh this queue"
	docQueue := SharedQueue new.

	"this semaphore keeps too many documents from beeing queueed up at a time"
	docQueueSema := Semaphore new.
	5 timesRepeat: [ docQueueSema signal ].

	"fork a process to download the updates"
	self retrieveUrls: urls ontoQueue: docQueue withWaitSema: docQueueSema.

	"process downloaded updates in the foreground"
	[ this _ docQueue next.
	  nextDoc _ docQueue next.  
	  nextDoc = #failed ifTrue: [ failed _ this ].
	  (failed isNil and: [ nextDoc ~= #finished ])
	] whileTrue: [
		failed ifNil: [
			nextDoc reset; text.
			nextDoc size = 0 ifTrue: [ failed _ this ]. ].
		failed ifNil: [
			nextDoc peek asciiValue = 4	"pure object file"
				ifTrue: [failed _ this]].	"Must be fileIn, not pure object file"
		failed ifNil: [
			"(this endsWith: '.html') ifTrue: [doc _ doc asHtml]."
				"HTML source code not supported here yet"
			updateImage ifTrue:	
				[ChangeSorter newChangesFromStream: nextDoc
					named: (this findTokens: '/') last].
			saveLocally ifTrue:
				[self saveUpdate: nextDoc onFile: (this findTokens: '/') last].	"if wanted"
			loaded _ loaded + 1].

		docQueueSema signal].
	].

	"report to user"
	str _ loaded printString ,' new update file(s) processed.'.
	failed ifNotNil: [str _ str, '\Could not load ' withCRs, 
		(urls size - loaded) printString ,' update file(s).',
		'\Starting with "' withCRs, failed, '".'].
	failed ifNil: [
		"DocLibrary external ifNotNil: [
			DocLibrary external updateMethodVersions] are not using this yet"].
	self inform: str.

