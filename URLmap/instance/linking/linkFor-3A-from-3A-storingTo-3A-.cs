linkFor: string from: peer storingTo: aList
	| uString newpage |
	uString _ string asUppercase.
	(self isStringRooted: uString)
		ifTrue: ["an external URL"
			(self isStringAnImage: uString)
				ifTrue: ["Looks like an image URL"
						^self imageURL: string]
				ifFalse: [^self externalURL: string]]
		ifFalse: [ "Serious! Gotta provide-a-link! But check for
image or local action first"
				(self isStringAnImage: uString)
					ifTrue: [^self localImageURL: string].
				(self isStringALocalAction: uString)
					ifTrue:[^self localActionURL: string].
			newpage _ pages at: string asLowercase ifAbsent: [nil].
			newpage isNil
				ifTrue: [ "Create a new page"
					newpage _ self newpage: string
from: peer.].
			(aList indexOf: newpage) ~= 0
				ifFalse: [aList add: newpage]. "Add only if
not there"
			^self pageURL: newpage]