click: evt
	| root popUp |
	root _ owner rootForGrabOf: self.
	root == nil
		ifTrue: ["Display hidden card in front"
				popUp _ self copy.
				self board owner owner addMorphFront: popUp.
				self world displayWorld.
				(Delay forMilliseconds: 750) wait.
				popUp delete]
		ifFalse: [evt hand grabMorph: root]