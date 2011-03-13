eToyRejectDropMorph: morphToDrop event: evt

	| tm am |

	tm _ TextMorph new 
		beAllFont: ((TextStyle named: #ComicBold) fontOfSize: 24);
		contents: 'GOT IT!'.
	(am _ AlignmentMorph new)
		color: Color yellow;
		layoutInset: 10;
		useRoundedCorners;
		vResizing: #shrinkWrap;
		hResizing: #shrinkWrap;
		addMorph: tm;
		fullBounds;
		position: (self bounds center - (am extent // 2));
		openInWorld: self world.
	(SampledSound soundNames includes: 'yum') ifFalse: [
		(FileDirectory default fileExists: '') ifTrue: [
			SampledSound addLibrarySoundNamed: 'yum' fromAIFFfileNamed: 'yum.aif'
		].
	].
	(SampledSound soundNames includes: 'yum') ifTrue: [
		SampledSound playSoundNamed: 'yum'
	].
	morphToDrop rejectDropMorphEvent: evt.		"send it back where it came from"
	am delete
