toggleIsGlobalFlap
	"Toggle whether the receiver is currently a global flap or not"

	| oldWorld |
	self hideFlap.  "In case showing"
	oldWorld _ self currentWorld.
	self isGlobalFlap
		ifTrue:
			[Utilities removeFromGlobalFlapTabList: self.
			oldWorld addMorphFront: self]
		ifFalse:
			[self delete.
			Utilities addGlobalFlap: self.
			self currentWorld addGlobalFlaps]
		