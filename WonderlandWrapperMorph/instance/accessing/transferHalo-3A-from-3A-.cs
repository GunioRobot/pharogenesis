transferHalo: event from: formerHaloOwner
	"Progressively transfer the halo to the next likely recipient"
	| localEvt |
	formerHaloOwner == self ifTrue:[self setProperty: #surviveHaloLoss toValue: true].
	"Never transfer halo to top-most world"
	(self wantsHaloFromClick and:[formerHaloOwner ~~ self]) 
		ifTrue:[^self addHalo: event from: formerHaloOwner].

	event shiftPressed ifTrue:[
		"Pass it outwards"
		^owner ifNotNil:[owner transferHalo: event from: formerHaloOwner]].
	self submorphsDo:[:m|
		localEvt _ event transformedBy: (m transformedFrom: self).
		(m fullContainsPoint: localEvt position) 
			ifTrue:[^m transferHalo: event from: formerHaloOwner].
	].
	"We're at the bottom most level; throw the event back up to the root to find recipient"
	^self getCameraMorph transferHalo: event from: formerHaloOwner.