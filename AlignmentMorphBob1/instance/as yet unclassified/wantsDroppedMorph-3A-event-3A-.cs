wantsDroppedMorph: aMorph event: evt

	| handlerForDrops |

	handlerForDrops _ self valueOfProperty: #handlerForDrops ifAbsent: [
		^super wantsDroppedMorph: aMorph event: evt
	].
	^handlerForDrops wantsDroppedMorph: aMorph event: evt in: self