justDroppedInto: aMorph event: anEvent
	"This message is sent to a dropped morph after it has been dropped on -- and been accepted by -- a drop-sensitive morph"

	| aWindow partsBinCase cmd aStack |
	self formerOwner: nil.
	self formerPosition: nil.
	cmd _ self valueOfProperty: #undoGrabCommand.
	cmd ifNotNil:[aMorph rememberCommand: cmd.
				self removeProperty: #undoGrabCommand].
	(partsBinCase _ aMorph isPartsBin) ifFalse:
		[self isPartsDonor: false].
	(aWindow _ aMorph ownerThatIsA: SystemWindow) ifNotNil:
		[aWindow isActive ifFalse:
			[aWindow activate]].
	(self isInWorld and: [partsBinCase not]) ifTrue:
		[self world startSteppingSubmorphsOf: self].
	"Note an unhappy inefficiency here:  the startStepping... call will often have already been called in the sequence leading up to entry to this method, but unfortunately the isPartsDonor: call often will not have already happened, with the result that the startStepping... call will not have resulted in the startage of the steppage."

	"An object launched by certain parts-launcher mechanisms should end up fully visible..."
	(self hasProperty: #beFullyVisibleAfterDrop) ifTrue:
		[aMorph == ActiveWorld ifTrue:
			[self goHome].
		self removeProperty: #beFullyVisibleAfterDrop].

	(self holdsSeparateDataForEachInstance and: [(aStack _ self stack) notNil])
		ifTrue:
			[aStack reassessBackgroundShape]
