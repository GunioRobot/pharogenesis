hostFontFromUser
	"StrikeFont hostFontFromUser"
	| fontNames index labels |
	fontNames _ self listFontNames asSortedCollection.
	labels _ WriteStream on: (String new: 100).
	fontNames do:[:fn| labels nextPutAll: fn] separatedBy:[labels cr].
	index _ (UIManager default chooseFrom: (labels contents substrings) 
				title: 'Choose your font').
	index = 0 ifTrue:[^nil].
	^fontNames at: index