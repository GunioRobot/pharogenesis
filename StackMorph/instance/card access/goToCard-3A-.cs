goToCard: destinationCard
	"Install the indicated destinationCard as the current card in the receiver.  Any viewer currently open on the current card will get retargeted to look at the new one."

	| aBackground existingCard oldViewers |
	aBackground _ self backgroundWithCard: destinationCard.
	existingCard _ aBackground currentDataInstance.
	oldViewers _ existingCard ifNil: [#()] ifNotNil: [existingCard allOpenViewers].

	aBackground installAsCurrent: destinationCard.

	aBackground ~~ currentPage ifTrue:
		["concern that need to run opening/closing scripts even when we're not going to a different background"
		self goToPageMorph: aBackground].

	oldViewers do: [:aViewer | aViewer retargetFrom: existingCard to: destinationCard]