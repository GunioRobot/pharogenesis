minHeight
	"Return the minimum height for this morph."

	| spaceNeeded |
	vResizing = #shrinkWrap ifFalse: [^super minHeight].

	submorphs isEmpty ifTrue: [^ self minHeightWhenEmpty].
	orientation == #horizontal ifTrue: [^super minHeight].
	orientation == #vertical ifTrue:
		[spaceNeeded _ 2 * (inset + borderWidth).
		spaceNeeded _ spaceNeeded + (PlayingCardMorph height).
		layout = #stagger ifTrue: [spaceNeeded _ spaceNeeded + 
									((self submorphCount - 1) * self staggerOffset)]].
	^ spaceNeeded
