mouseDownEvent: evt for: aSubmorph

	| why aMenu |

	why _ aSubmorph valueOfProperty: #intentOfDroppedMorphs.
	why == #changeTargetMorph ifTrue: [
		aMenu _ MenuMorph new
			defaultTarget: self.
		{
			{'Rectangle'. RectangleMorph}.
			{'Ellipse'. EllipseMorph}
		} do: [ :pair |
			aMenu	
				add: pair first translated
				target: self 
				selector: #attachMorphOfClass:to: 
				argumentList: {pair second. evt hand}.
		].
		aMenu popUpEvent: evt in: self world.
		^self
	].

