loadActor
	| strm filename |
	"Why does this open the file? Hrmpf."
	strm _ FileList2 modalFileSelectorForSuffixes: #('mdl' 'wrl' '3ds').
	strm ifNil: [^nil].
	filename _ strm name.
	strm close.
	(filename endsWith: 'mdl')
		ifTrue: [^ self makeActorFrom: filename].
	(filename endsWith: 'wrl')
		ifTrue: [^ self makeActorFromVRML: filename].
	(filename endsWith: '3ds')
		ifTrue: [^ self makeActorFrom3DS: filename].
	self error: 'Huh?'