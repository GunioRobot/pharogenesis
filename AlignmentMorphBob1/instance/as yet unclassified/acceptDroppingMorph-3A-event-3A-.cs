acceptDroppingMorph: aMorph event: evt

	| handlerForDrops |

	handlerForDrops _ self valueOfProperty: #handlerForDrops ifAbsent: [
		^super acceptDroppingMorph: aMorph event: evt
	].
	(handlerForDrops acceptDroppingMorph: aMorph event: evt in: self) ifFalse: [
		aMorph rejectDropMorphEvent: evt.		"send it back where it came from"
	].