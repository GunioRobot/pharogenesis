readTrackContents: byteCount

	| info |
	strings _ OrderedCollection new.
	track _ OrderedCollection new.
	trackStream _ ReadStream on: (stream next: byteCount).
	activeEvents _ OrderedCollection new.
	self readTrackEvents.
	(tracks isEmpty and: [self isTempoTrack: track])
		ifTrue: [tempoMap _ track asArray]
		ifFalse: [
			track size > 0 ifTrue: [
			tracks add: track asArray.
			info _ WriteStream on: (String new: 100).
			strings do: [:s | info nextPutAll: s; cr].
			trackInfo add: info contents]].
	strings _ track _ trackStream _ activeEvents _ nil.
