storeNewPrimaryURL: aURLString

	urlList isEmptyOrNil ifTrue: [urlList _ Array new: 1].
	urlList at: 1 put: aURLString
