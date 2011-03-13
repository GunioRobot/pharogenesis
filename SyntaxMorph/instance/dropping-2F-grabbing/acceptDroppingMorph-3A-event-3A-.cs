acceptDroppingMorph: aMorph event: evt
	| itNoun old |
	"For the moment, you have to drop it the right place.  We do not look at enclosing morphs"
	"Two ways to do this:  Must always destroy old node, then drag in new one.
		Or, drop replaces what you drop on.  Nasty with blocks.  see wantsDroppedMorph:event:"
	"We know it is acceptable.  Just a matter of which case"

	itNoun _ aMorph isNoun.
	self withAllOwnersDo:
		[:m | (m isSyntaxMorph and: [m isBlockNode])
			ifTrue: [m stopStepping; removeDropZones]].
	self isBlockNode & itNoun
		ifTrue:
			[(aMorph nodeClassIs: TempVariableNode) ifTrue:
				["If I am a BlockNode, and it is a TempVariableNode, add it into list"
				^ (self addBlockArg: aMorph) ifFalse:
					["if already declared, start new line of code with it"
					self addToBlock: aMorph event: evt]]	
		ifFalse:
			[^ self addToBlock: aMorph event: evt]].

	"If I am a BlockNode and it is a noun add it as a new line"
	self isBlockNode ifTrue: [
		 (aMorph nodeClassIs: ReturnNode) ifTrue: [^ self addToBlock: aMorph event: evt]].

	"Later add args and keywords.  later allow comments to be dropped"

	"Can't put statement, literal, assignment, or cascade into left side of assignment"
	(owner isSyntaxMorph) ifTrue:
		[(owner nodeClassIs: AssignmentNode) ifTrue:
			[(owner submorphIndexOf: self) = 1 ifTrue:
				[((aMorph nodeClassIs: TempVariableNode)
				or: [aMorph nodeClassIs: VariableNode])  ifFalse: [ ^ self]]]].

	aMorph deselect.
	(old _ owner) replaceSubmorph: self by: aMorph.	"do the normal replacement"
	old cleanupAfterItDroppedOnMe.	"now owned by no one"
