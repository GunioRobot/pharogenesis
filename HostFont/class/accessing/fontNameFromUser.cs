fontNameFromUser
	"HostFont fontNameFromUser"
	| fontNames index labels |
	fontNames _ self listFontNames asSortedCollection.
	labels _ WriteStream on: (String new: 100).
	fontNames do:[:fn| labels nextPutAll: fn] separatedBy:[labels cr].
	index _ (PopUpMenu labels: labels contents) startUpWithCaption:'Choose your font'.
	index = 0 ifTrue:[^nil].
	^fontNames at: index