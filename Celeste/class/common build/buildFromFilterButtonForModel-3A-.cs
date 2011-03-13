buildFromFilterButtonForModel: model 
	| sw b buttonViewClass |
	Smalltalk isMorphic
		ifTrue: [buttonViewClass _ self morphicButtonsClass]
		ifFalse: [buttonViewClass _ PluggableButtonView].
	sw _ Switch new.
	b _ buttonViewClass on: (sw
					onAction: [model fromFilterOn: sw];
					
					offAction: [model fromFilterOff]).
	b label: 'From F.';
		 borderWidth: 1.
	b setBalloonText: 'Show messages with specific From: line content'.
	^ b