stopListening
	GlobalListener ifNotNil:
		[GlobalListener stopListening.
		GlobalListener _ nil.
		self bumpUpdateCounter]

	"EToyListenerMorph stopListening"