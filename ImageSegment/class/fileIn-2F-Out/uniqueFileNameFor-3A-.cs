uniqueFileNameFor: segName
	"Choose a unique file name for the segment with this name."
	| segDir fileName listOfFiles |
	segDir _ self segmentDirectory.
	listOfFiles _ segDir fileNames.
	BiggestFileNumber ifNil: [BiggestFileNumber _ 1].
	BiggestFileNumber > 99 ifTrue: [BiggestFileNumber _ 1].	"wrap"
	[fileName _ segName, BiggestFileNumber printString, '.seg'.
	 (listOfFiles includes: fileName)] whileTrue: [
		BiggestFileNumber _ BiggestFileNumber + 1].	"force a unique file name"
	^ fileName