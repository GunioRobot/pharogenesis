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
"When two sets of updates need to use the same directory, one of them has a * in its 
serverUrls description.  When that is true, the first word of the description is put on
the front of 'updates.list', and that is the index file used."

"Utilities readServerUpdatesThrough: 3922 saveLocally: true updateImage: true"

	| failed loaded str res servers triple tryAgain indexPrefix |
	Utilities chooseUpdateList ifFalse: [^ self].	"ask the user which kind of updates"

	servers _ Utilities serverUrls copy.
	indexPrefix _ (Utilities updateUrlLists first first includes: $*) 
		ifTrue: [(Utilities updateUrlLists first first findTokens: ' ') first]
						"special for internal updates"
		ifFalse: ['']. 	"normal"
	[servers isEmpty] whileFalse: [
		triple _ self readServer: servers special: indexPrefix 
					updatesThrough: maxNumber 
					saveLocally: saveLocally updateImage: updateImage.

		"report to user"
		failed _ triple first.
		loaded _ triple second.
		tryAgain _ false.
		failed ifNil: ["is OK"
			loaded = 0 ifTrue: ["found no updates"
				servers size > 1 ifTrue: ["not the last server"
					res _ PopUpMenu withCaption: 
'No new updates on the server
', servers first, '
Would you like to try the next server?
(Normally, all servers are identical, but sometimes a
server won''t let us store new files, and gets out of date.)' 
						chooseFrom: 'Stop looking\Try next server'.
					res = 2 ifFalse: [^ self]
						 ifTrue: [servers _ servers allButFirst.	"try the next server"
							tryAgain _ true]]]].
		tryAgain ifFalse: [
			str _ loaded printString ,' new update file(s) processed.'.
			^ self inform: str].
	].