storeNewPrimaryURL: aURLString
	| oldResourceUrl |
	oldResourceUrl _ self resourceUrl.
	urlList isEmptyOrNil ifTrue: [urlList _ Array new: 1].
	urlList at: 1 put: aURLString.
	self lastDirectory: nil.
	self resourceManager adjustToNewServer: self resourceUrl from: oldResourceUrl
