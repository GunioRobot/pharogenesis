subtitleForFrame: frameNumber 
	"answer the subtitle for the given frame number"
	| element |
	element := self elementCorrespondingToFrame: frameNumber.
	^ element isNil
		ifTrue: ['']
		ifFalse: [element contents]