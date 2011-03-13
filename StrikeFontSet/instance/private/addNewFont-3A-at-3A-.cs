addNewFont: aFont at: encodingIndex

	| newArray |
	encodingIndex > fontArray size ifTrue: [
		newArray _ Array new: encodingIndex.
		newArray replaceFrom: 1 to: fontArray size with: fontArray startingAt: 1.
	] ifFalse: [
		newArray _ fontArray.
	].

	newArray at: encodingIndex put: aFont.

	self initializeWithFontArray: newArray.
