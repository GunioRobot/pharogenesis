absorbUpdatesFromServer
	"Go to two common servers and look for updates.  Do not bring them
to the user's disk.  A file on the server called updates.list has the names
of the last N update files.  We look backwards for the first one we do not
have, and start there bringing them in.  tk 9/10/97"
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
"Utilities absorbUpdatesFromServer"

| doc urls failed str |
Cursor wait showWhile: [
	urls _ self newUpdatesOn: ((Smalltalk at: #EToySystem) serverUrls collect:
		[:url | url, 'updates/']).
	failed _ 0.
	urls do: [:this |
		doc _ HTTPSocket httpGet: this accept: 'application/octet-stream'.
		"check here that it worked"
		doc class == String
			ifTrue: [failed _ failed + 1]	"an error loading"
			ifFalse: [
				doc reset; text.
				doc peek asciiValue = 4	"pure object file"
					ifTrue: [failed _ failed + 1]	"Must be fileIn, not pure object file"
					ifFalse: [
						"(this endsWith: '.html') ifTrue: [doc _ doc asHtml]."
							"HTML source code not supported here yet"
						ChangeSorter newChangesFromStream: doc
							named: (this findTokens: '/') last]]].
	].
str _ 'Loaded ', (urls size - failed) printString ,' new update files.'.
failed > 0 ifTrue: [str _ str, '\Could not find ' withCRs, failed printString ,' update files.'].
self inform: str.