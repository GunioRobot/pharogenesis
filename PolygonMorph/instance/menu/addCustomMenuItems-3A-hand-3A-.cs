addCustomMenuItems: aCustomMenu hand: aHandMorph
	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	handles == nil
		ifTrue: [aCustomMenu add: 'show handles' action: #addHandles]
		ifFalse: [aCustomMenu add: 'hide handles' action: #removeHandles].
	closed
		ifTrue:
		[aCustomMenu add: 'open polygon' action: #makeOpen.
		quickFill
			ifTrue: [aCustomMenu add: 'proper fill' selector: #quickFill: argument: false]
			ifFalse: [aCustomMenu add: 'quick fill' selector: #quickFill: argument: true]]
		ifFalse:
		[aCustomMenu add: 'close polygon' action: #makeClosed.
		arrows == #none ifFalse: [aCustomMenu add: '---' action: #makeNoArrows].
		arrows == #forward ifFalse: [aCustomMenu add: '-->' action: #makeForwardArrow].
		arrows == #back ifFalse: [aCustomMenu add: '<--' action: #makeBackArrow].
		arrows == #both ifFalse: [aCustomMenu add: '<-->' action: #makeBothArrows]]