play
	| separator |
	self isPlaying: true.
	notesIndex = 0 ifTrue: [
		recorder pause.
		recorder playback.
		self isPlaying: false.
		^self
	].
	separator _ FileDirectory pathNameDelimiter asString.
	sound _ (AIFFFileReader new readFromFile: (
		FileDirectory default pathName, 
		separator, 'audio', separator, (notes at: notesIndex), 'aiff')) sound.
	[
		sound playAndWaitUntilDone.
		self isPlaying: false
	] fork